using AutoMapper;
using Shop.BL;
using Shop.DAL.Entities;
using Shop.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.DTO;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//הזרקת תלויות, יצירת סקופ, תוצרת חיים

//builder.Services.AddScoped<IOrdersProductBL, OrdersProductBL>();
//builder.Services.AddScoped<IOrdersProductDL, OrdersProductDL>();
builder.Services.AddScoped<IOrdersBL, OrdersBL>();
builder.Services.AddScoped<IOrdersDAL, OrdersDAL>();
//builder.Services.AddScoped<ILookupBL, LookupBL>();
//builder.Services.AddScoped<ILookupDL, LookupDL>();
builder.Services.AddScoped<IProductsBL, ProductsBL>();
builder.Services.AddScoped<IProductsDAL, ProductsDAL>();
//builder.Services.AddScoped<IProductInCartBL, ProductInCartBL>();
//builder.Services.AddScoped<IProductInCartDL1, ProductInCartDL>();
builder.Services.AddScoped<IUsersBL, UsersBL>();
builder.Services.AddScoped<IUsersDAL, UsersDAL>();

//public ISer

builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);

builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlServer("Server=DESKTOP-JVFBNR1\\SQLEXPRESS04;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True;"));

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
