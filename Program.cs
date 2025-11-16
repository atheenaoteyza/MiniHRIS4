using Microsoft.EntityFrameworkCore;
using MiniHRIS4.Models;
using MiniHRIS4.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.WriteTo.Console().WriteTo.File("Logs/log_.txt", rollingInterval: RollingInterval.Day)
.Enrich.FromLogContext().CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MiniHRIS4Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiniHRIS4Context")));

builder.Services.AddScoped<MiniHRISServices>();
var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseMiddleware<ErrorHandlingMiddleware>();

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
