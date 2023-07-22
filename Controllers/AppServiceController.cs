using Microsoft.AspNetCore.Mvc;
using MultiEcho.Models.Dtos;
using MultiEcho.Services;

namespace MultiEcho.Controllers;

[ApiController]
[Route("[controller]")]
public class AppServiceController : ControllerBase
{
    private readonly IAppService appService;

    public AppServiceController(IAppService appService)
    {
        this.appService = appService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateAppServiceDto dto)
    {
        await appService.Create(dto);
        return Ok();
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(int id)
    {
        var app = await appService.Get(id);
        return Ok(app);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var apps = await appService.Get();
        return Ok(apps);
    }
}