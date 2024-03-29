using Microsoft.EntityFrameworkCore;
using DAL.Data;
using BAL.Interfaces;
using BAL.Services;
using EF_Core.ViewModels.ModelMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//DB
builder.Services.AddDbContext<ShoppingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Services
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ISupermarketService, SupermarketService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
