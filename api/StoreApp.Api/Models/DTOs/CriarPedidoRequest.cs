namespace StoreApp.Api.Models.DTOs;

public class CriarPedidoRequest
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Endereco { get; set; } = string.Empty;

    public string MeioPagamento { get; set; } = string.Empty;

    public List<CriarPedidoItemRequest> Produtos { get; set; } = new();
}