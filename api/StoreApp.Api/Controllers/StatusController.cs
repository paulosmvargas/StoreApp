using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API running");
    }
}