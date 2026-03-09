using Microsoft.AspNetCore.Mvc;
using StoreApp.Api.Services;

namespace StoreApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var produtos = await _produtoService.GetProdutosAsync();

        return Ok(produtos);
    }
}