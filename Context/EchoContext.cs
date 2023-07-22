using Microsoft.EntityFrameworkCore;
using MultiEcho.Models.Enitites;

namespace MultiEcho.Context;

public class EchoContext : DbContext
{
    public EchoContext(DbContextOptions<EchoContext> options) : base(options)
    {
            
    }
    
    public DbSet<App> Apps { get; set; }
    public DbSet<CallTime> CallTimes { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CallTime>()
            .HasOne(b => b.App) 
            .WithMany(a => a.CallTimes)   
            .HasForeignKey(b => b.AppId) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}