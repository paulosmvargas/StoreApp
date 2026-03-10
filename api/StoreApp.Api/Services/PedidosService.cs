using Microsoft.EntityFrameworkCore;
using StoreApp.Api.Data;
using StoreApp.Api.Models.DTOs;
using StoreApp.Api.Models.Entities;

namespace StoreApp.Api.Services;

public class PedidosService
{
    private readonly AppDbContext _context;

    public PedidosService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CriarPedidoAsync(CriarPedidoRequest request)
    {
        var pedido = new Pedido
        {
            NomeCliente = request.Nome,
            Email = request.Email,
            Endereco = request.Endereco,
            MeioPagamento = request.MeioPagamento
        };

        foreach (var item in request.Produtos)
        {
            pedido.Itens.Add(new PedidoItem
            {
                ProdutoId = item.ProdutoId,
                NomeProduto = $"Produto {item.ProdutoId}",
                Valor = 0,
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