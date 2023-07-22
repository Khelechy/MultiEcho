using Microsoft.EntityFrameworkCore;
using MultiEcho.Context;
using MultiEcho.Models.Dtos;
using MultiEcho.Models.Enitites;

namespace MultiEcho.Services;

public interface IAppService
{
    Task Create(CreateAppServiceDto dto);
    Task<List<App>> Get();
    Task<App> Get(int id);
}
public class AppService : IAppService
{
    private readonly EchoContext context;
    private readonly ICallTimeService callTimeService;

    public AppService(EchoContext context, ICallTimeService callTimeService)
    {
        this.context = context;
        this.callTimeService = callTimeService;
    }
    
    public async Task Create(CreateAppServiceDto dto)
    {
        var app = new App
        {
            Name = dto.Name,
            Url = dto.Url,
            IntervalInMinutes = dto.IntervalInMinutes
        };

        await context.Apps.AddAsync(app);
        await context.SaveChangesAsync();

        var callTimes = await callTimeService.BulkCreate(app);
        if (callTimes != null)
        {
            app.CallTimes = callTimes;
        }
        
        await context.SaveChangesAsync();
    }

    public async Task<List<App>> Get()
    {
        var apps = await context.Apps.ToListAsync();
        return apps;
    }

    public async Task<App> Get(int id)
    {
        var app = await context.Apps.FirstOrDefaultAsync(x => x.Id == id);
        return app;
    }
}