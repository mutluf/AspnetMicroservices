using Order.Application;
using Order.Persistence;
using Order.Infrastructure;
using Order.Persistence.Context;
using Order.API.Extensions;
using MassTransit;
using EventBus.Messages.Common;
using Order.API.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();


    config.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration["EventBusSettings:HostAddress"]);


        configurator.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => c.ConfigureConsumer<BasketCheckoutConsumer>(context));

    });
});

//builder.Services.AddScoped<BasketCheckoutConsumer>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.MigrateDatabase<OrderDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<OrderContextDbSeed>>();
    OrderContextDbSeed
        .SeedAsync(context, logger)
        .Wait();
});
app.Run();
