import { NextResponse, type NextRequest } from "next/server";

// Checagem otimista: sem o cookie de login, nem renderiza a área logada.
// A validação real continua na API (.NET), que devolve 401 se o cookie for inválido.
export function proxy(request: NextRequest) {
  const logado = request.cookies.has("sgfju.auth");
  const { pathname } = request.nextUrl;

  if (!logado && pathname !== "/login") {
    const url = new URL("/login", request.url);
    if (pathname !== "/") url.searchParams.set("voltar", pathname);
    return NextResponse.redirect(url);
  }
  return NextResponse.next();
}

export const config = {
  // Não intercepta a API, arquivos estáticos do Next nem imagens.
  matcher: ["/((?!api|_next/static|_next/image|favicon.ico|.*\\.(?:png|jpg|jpeg|svg|ico|webp)$).*)"],
};
