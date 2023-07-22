using Microsoft.EntityFrameworkCore;
using MultiEcho.Context;
using MultiEcho.Models.Enitites;

namespace MultiEcho.Services;

public interface ICallTimeService
{
    Task<List<CallTime>> BulkCreate(App app);
}

public class CallTimeService : ICallTimeService
{
    private readonly EchoContext context;

    public CallTimeService(EchoContext context)
    {
        this.context = context;
    }
    
    public async Task<List<CallTime>> BulkCreate(App app)
    {
        var times = GenerateTimesForInterval(app.IntervalInMinutes);
        var callTimes = times.Select(time => new CallTime
        {
            Time = time,
            AppId = app.Id,
            Url = app.Url
        }).ToList();

        await context.CallTimes.AddRangeAsync(callTimes);
        await context.SaveChangesAsync();

        return callTimes;
    }

    public async Task<List<CallTime>> GetForTime(string time)
    {
        var calltimes = await context.CallTimes.Where(x => x.Time == time).ToListAsync();
        return calltimes;
    }


    private List<string> GenerateTimesForInterval(int intervalInMinutes)
    {
        var times = new List<string>();
        int hour = 0;
        int minute = 0;

        while (hour < 24)
        {
            var currentMinute = $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}";
            times.Add(currentMinute);
            
            minute += intervalInMinutes;
            
            while (minute >= 60) {
                hour++;
                minute -= 60;
            }
        }

        return times;
    }
}