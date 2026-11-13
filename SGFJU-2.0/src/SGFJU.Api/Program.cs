using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SGFJU.Api.Legado;
using SGFJU.Domain.Model.Infra.Util;

var builder = WebApplication.CreateBuilder(args);

// ---- Configuração (substitui o web.config) ---------------------------------------------
// A senha do banco NUNCA fica no appsettings.json versionado. Use:
//   dotnet user-secrets set "ConnectionStrings:banco" "Server=...;Database=...;Uid=...;Pwd=..."
// ou a variável de ambiente ConnectionStrings__banco em produção.
var appSettings = builder.Configuration.GetSection("AppSettings")
    .GetChildren()
    .ToDictionary(c => c.Key, c => c.Value);
SgfjuConfig.Configure(builder.Configuration.GetConnectionString("banco"), appSettings);

// ---- Serviços -------------------------------------------------------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services
    .AddControllers(options =>
    {
        // Toda a API exige login, exceto o que estiver marcado com [AllowAnonymous].
        options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
    })
    .AddJsonOptions(options =>
    {
        // Mantém PascalCase, igual ao Web API 2 antigo, para que os contratos não mudem.
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    });

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "sgfju.auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        // API não redireciona para tela de login: devolve 401/403 e o front decide.
        options.Events.OnRedirectToLogin = ctx => { ctx.Response.StatusCode = StatusCodes.Status401Unauthorized; return Task.CompletedTask; };
        options.Events.OnRedirectToAccessDenied = ctx => { ctx.Response.StatusCode = StatusCodes.Status403Forbidden; return Task.CompletedTask; };
    });
builder.Services.AddAuthorization();

var origens = builder.Configuration.GetSection("Sgfju:OrigensPermitidas").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.WithOrigins(origens).AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

var app = builder.Build();

var pastaLegado = builder.Configuration["Sgfju:PastaConteudoLegado"] ?? app.Environment.ContentRootPath;
if (!System.IO.Path.IsPathRooted(pastaLegado))
    pastaLegado = System.IO.Path.Combine(app.Environment.ContentRootPath, pastaLegado);
AmbienteLegado.Configurar(app.Services.GetRequiredService<IHttpContextAccessor>(), pastaLegado);

// ---- Pipeline -------------------------------------------------------------------------
// Os controllers antigos lançam Exception com a mensagem já tratada. Devolvemos isso como
// ProblemDetails (JSON) em vez de uma página de erro HTML.
app.UseExceptionHandler(erro => erro.Run(async contexto =>
{
    var excecao = contexto.Features.Get<IExceptionHandlerFeature>()?.Error;
    var logger = contexto.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("SGFJU");
    logger.LogError(excecao, "Erro não tratado em {Path}", contexto.Request.Path);

    contexto.Response.StatusCode = StatusCodes.Status500InternalServerError;
    await contexto.Response.WriteAsJsonAsync(new
    {
        title = "Erro ao processar a requisição",
        status = 500,
        detail = app.Environment.IsDevelopment() ? excecao?.Message : "Ocorreu um erro inesperado. Tente novamente."
    });
}));

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok", versao = "2.0" })).AllowAnonymous();
app.MapControllers();

app.Run();
