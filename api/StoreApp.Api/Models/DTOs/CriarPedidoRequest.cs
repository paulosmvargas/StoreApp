using System.ComponentModel.DataAnnotations;
using StoreApp.Api.Models.Enums;
namespace StoreApp.Api.Models.DTOs;

public class CriarPedidoRequest
{
    [Required]
    [MinLength(3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MinLength(5)]
    public string Endereco { get; set; } = string.Empty;

    [Required]
    [RegularExpression("Pix|Cartao|Boleto", ErrorMessage = "Meio de Pagamento deve ser Pix, Cartao ou Boleto")]
    public string MeioPagamento { get; set; } = string.Empty;

    [Required]
    [MinLength(1, ErrorMessage = "O pedido deve conter pelo menos um produto")]
    public List<CriarPedidoItemRequest> Produtos { get; set; } = new();
}