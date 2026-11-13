using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Os DTOs antigos usam char para Sim/Não ('S'/'N'). Este conversor aceita "" ou null como "não informado" ('\0'),
    /// e na saída devolve "" em vez do caractere nulo.
    /// </summary>
    public sealed class CharJsonConverter : JsonConverter<char>
    {
        public override char Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return '\0';
            if (reader.TokenType == JsonTokenType.String)
            {
                var s = reader.GetString();
                return string.IsNullOrEmpty(s) ? '\0' : s[0];
            }
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var n)) return (char)n;
            throw new JsonException("Valor inválido para campo de um caractere.");
        }

        public override void Write(Utf8JsonWriter writer, char value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value == '\0' ? "" : value.ToString());
    }
}
