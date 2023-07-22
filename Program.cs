using Microsoft.EntityFrameworkCore;
using MultiEcho.Context;
using MultiEcho.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EchoContext>(option => option.UseNpgsql
    (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddScoped<ICallTimeService, CallTimeService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();