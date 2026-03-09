namespace StoreApp.Api.Models.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal Preco { get; set; }

    public int Estoque { get; set; }

    public string Imagem { get; set; } = string.Empty;
}