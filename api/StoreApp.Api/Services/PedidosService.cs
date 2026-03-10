using Microsoft.EntityFrameworkCore;
using StoreApp.Api.Data;
using StoreApp.Api.Models.DTOs;
using StoreApp.Api.Models.Entities;
using StoreApp.Api.Models.Enums;

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

        // valida produtos duplicados no mesmo pedido
        var duplicated = request.Produtos
            .GroupBy(p => p.ProdutoId)
            .Any(g => g.Count() > 1);

        if (duplicated)
            throw new ArgumentException("Produtos duplicados no pedido");

        var pedido = new Pedido
        {
            NomeCliente = request.Nome,
            Email = request.Email,
            Endereco = request.Endereco,
            MeioPagamento = Enum.Parse<MeiosPagamento>(request.MeioPagamento)
        };

        foreach (var item in request.Produtos)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == item.ProdutoId);

            if (produto == null)
                throw new ArgumentException($"Produto {item.ProdutoId} não encontrado");

            if (produto.Estoque <= 0)
                throw new InvalidOperationException($"Produto {produto.Nome} sem estoque");

            if (item.Quantidade > produto.Estoque)
                throw new InvalidOperationException($"Estoque insuficiente para {produto.Nome}");

            pedido.Itens.Add(new PedidoItem
            {
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                Valor = produto.Preco,
                Quantidade = item.Quantidade
            });
        }

        using var transaction = await _context.Database.BeginTransactionAsync();

        _context.Pedidos.Add(pedido);

        await _context.SaveChangesAsync();

        await transaction.CommitAsync();

        return pedido.Id;
    }

    public async Task<Pedido?> GetPedidoAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}