using System.Text.Json.Serialization;

namespace StoreApp.Api.Models.Entities;

public class PedidoItem
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    [JsonIgnore]
    public Pedido Pedido { get; set; } = null!;

    public int ProdutoId { get; set; }

    public string NomeProduto { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public int Quantidade { get; set; }
}