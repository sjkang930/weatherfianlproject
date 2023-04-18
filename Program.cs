using Weather.Models;
using Microsoft.EntityFrameworkCore;
using Weather.Hubs;
using Npgsql;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);


var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
// var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
// builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
Console.WriteLine($"Connection string: {connectionString}");
builder.Services.AddDbContext<DatabaseContext>(
    opt =>
    {
      opt.UseNpgsql(connectionString);
      if (builder.Environment.IsDevelopment())
      {
        opt
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors();
      }
    }
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
// app


var app = builder.Build();
app.MapControllers();


app.MapHub<ChatHub>("/r/chat");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseDefaultFiles();
// app.UseStaticFiles();
// app.MapFallbackToFile("index.html");
app.Run();
