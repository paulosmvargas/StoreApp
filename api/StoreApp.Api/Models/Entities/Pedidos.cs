using System.ComponentModel.DataAnnotations;

namespace StoreApp.Api.Models.Entities;

public class Pedido
{
    public int Id { get; set; }

    [Required]
    public string NomeCliente { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Endereco { get; set; } = string.Empty;

    [Required]
    public string MeioPagamento { get; set; } = string.Empty;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public List<PedidoItem> Itens { get; set; } = new();
}