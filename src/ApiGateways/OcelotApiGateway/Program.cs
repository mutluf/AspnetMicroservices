using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(c =>
{
    c.AddConfiguration(builder.Configuration.GetSection("Logging"));
    c.AddConsole();
    c.AddDebug();
});

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


await app.UseOcelot();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}