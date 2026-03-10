using System.Text.Json;
using StoreApp.Api.External;
using StoreApp.Api.Models.DTOs;

namespace StoreApp.Api.Services;

public class ProdutoService
{
    private readonly HttpClient _httpClient;

    public ProdutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProdutoDTO>> GetProdutosAsync()
    {
        var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var produtos = JsonSerializer.Deserialize<List<FakeStoreProduto>>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return produtos!.Select(p => new ProdutoDTO
        {
            Id = p.Id,
            Nome = p.Title,
            Descricao = p.Description,
            Preco = p.Price,
            Estoque = Random.Shared.Next(0, 25),
            Imagem = p.Image
        }).ToList();
    }
}