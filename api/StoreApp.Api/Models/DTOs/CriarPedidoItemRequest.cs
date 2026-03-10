using System.ComponentModel.DataAnnotations;
namespace StoreApp.Api.Models.DTOs;

public class CriarPedidoItemRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int ProdutoId { get; set; }
    
    [Required]
    [Range(1, 100)]
    public int Quantidade { get; set; }
}