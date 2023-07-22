using System.ComponentModel.DataAnnotations;

namespace MultiEcho.Models.Enitites;

public class App
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public int IntervalInMinutes { get; set; }
    public ICollection<CallTime> CallTimes { get; set; }
}