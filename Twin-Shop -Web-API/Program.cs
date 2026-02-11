using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Repositories.Implementations;
using Twin_Shop__Web_API.Repositories.Interfaces;
using Twin_Shop__Web_API.Services.Interfaces;
using Twin_Shop__Web_API.Services.Implementations;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    Environment.GetEnvironmentVariable("TWIN_SHOP_CONNECTION")
 ?? throw new Exception("Environment variable TWIN_SHOP_CONNECTION is not set");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBrandService, BrandService> ();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(cfg => { },typeof(Program).Assembly);
builder.Services.AddScoped<IUserRepository, UserRepository>();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
