using System.ComponentModel.DataAnnotations;

namespace MultiEcho.Models.Enitites;

public class CallTime
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public string Time { get; set; }
    
    public int AppId { get; set; }
    public App App { get; set; }
}