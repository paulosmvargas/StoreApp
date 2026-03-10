using System.Text.Json.Serialization;

namespace StoreApp.Api.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MeiosPagamento
{
    Pix,
    Cartao,
    Boleto
}