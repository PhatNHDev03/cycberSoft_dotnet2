using Microsoft.EntityFrameworkCore;
using session40_50.Interfaces;
using session40_50.Repsitory;
using session40_50.Services;
using session40_52.Data;
using session40_52.Interfaces;
using session40_52.Repsitory;
using session40_52.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// dang ki api va nhung controller khac cho webApi
builder.Services.AddControllers();
// dang ki swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//register phai theo thu tu
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserService, AuthService>(); // khai bao service 
builder.Services.AddScoped<IUserRepository, AuthRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

