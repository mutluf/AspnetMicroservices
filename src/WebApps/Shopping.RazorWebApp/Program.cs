using Shopping.RazorWebApp.Data;
using Shopping.RazorWebApp.Repositories.Abstractions;
using Shopping.RazorWebApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Shopping.RazorWebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShoppingDbContext>(c =>
                c.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.SeedDatabase();
app.Run();
