using Hangfire;
using HikingGearShop.CommonDataAccess;
using HikingGearShop.EmailService;
using HikingGearShop.OrderService.Data;
using HikingGearShop.ProductService.Data;
using HikingGearShop.ProductService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("HikingGearShopDB");

builder.Services.AddDbContext<ShopDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped
// Skal kunne add til cart

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Hangfire services
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<IEmailService>(x => x.SendMonthyOrdersEmail(), Cron.Monthly);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


