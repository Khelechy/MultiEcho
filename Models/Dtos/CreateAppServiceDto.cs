namespace MultiEcho.Models.Dtos;

public class CreateAppServiceDto
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public int IntervalInMinutes { get; set; }
}