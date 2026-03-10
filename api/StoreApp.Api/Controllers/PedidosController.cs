using Microsoft.AspNetCore.Mvc;
using StoreApp.Api.Models.DTOs;
using StoreApp.Api.Services;

namespace StoreApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly PedidosService _pedidosService;

    public PedidosController(PedidosService pedidosService)
    {
        _pedidosService = pedidosService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CriarPedidoRequest request)
    {
        var pedidoId = await _pedidosService.CriarPedidoAsync(request);

        return Ok(new { pedidoId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pedido = await _pedidosService.GetPedidoAsync(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }
}