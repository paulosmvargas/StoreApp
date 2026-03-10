using Microsoft.EntityFrameworkCore;
using StoreApp.Api.Data;
using StoreApp.Api.Models.DTOs;
using StoreApp.Api.Models.Entities;

namespace StoreApp.Api.Services;

public class PedidosService
{
    private readonly AppDbContext _context;
    private readonly ProdutoService _produtoService;

    public PedidosService(AppDbContext context, ProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }

    public async Task<int> CriarPedidoAsync(CriarPedidoRequest request)
    {
        var produtos = await _produtoService.GetProdutosAsync();

        var pedido = new Pedido
        {
            NomeCliente = request.Nome,
            Email = request.Email,
            Endereco = request.Endereco,
            MeioPagamento = request.MeioPagamento
        };

        if (!request.Produtos.Any())
            throw new Exception("Pedido precisa ter ao menos um produto!");

        foreach (var item in request.Produtos)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
            
            if (produto == null)
                throw new Exception($"Product {item.ProdutoId} not found");

            pedido.Itens.Add(new PedidoItem
            {
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                Valor = produto.Preco,
                Quantidade = item.Quantidade
            });
        }

        _context.Pedidos.Add(pedido);

        await _context.SaveChangesAsync();

        return pedido.Id;
    }

    public async Task<Pedido?> GetPedidoAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}