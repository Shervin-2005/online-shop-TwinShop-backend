using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Twin_Shop__Web_API.Middlewares;
using Twin_Shop__Web_API.Middlewares.ExceptionHandler;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Implementations;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.BLL.Services.SMSService.Implementations;
using TwinShop.BLL.Services.SMSService.Interfaces;
using TwinShop.BLL.Services.SMSService.Options;
using TwinShop.BLL.Services.UploadImageService.Implementations;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Options;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Implementations;
using TwinShop.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    Environment.GetEnvironmentVariable("TWIN_SHOP_CONNECTION")
 ?? throw new Exception("Environment variable TWIN_SHOP_CONNECTION is not set");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo
    .MSSqlServer(
    connectionString: connectionString,
    sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true })
    .WriteTo.File("Logs/log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173"  
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials(); 
    });
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandValidationService, BrandValidationService>();
builder.Services.AddScoped<ISaveBrandImageService, SaveBrandImageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
builder.Services.AddScoped<ISaveProductImagesService, SaveProductImagesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserValidationService, UserValidationService>();
builder.Services.AddScoped<ISaveUserProfileImageService, SaveUserProfileImageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryValidationService, CategoryValidationService>();
builder.Services.AddScoped<ISaveCategoryImageService, SaveCategoryImageService>();
builder.Services.AddScoped<IOTPRepository, OTPRepository>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<ISavePhotoService, SavePhotoService>();
builder.Services.AddScoped<IFileValidatorService, FileValidatorService>();
builder.Services.AddSingleton<IExceptionHandler, NotFoundExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, AmazonS3ExceptionHandler>();
builder.Services.AddSingleton < IExceptionHandler, BadRequestExceptionHandler>();
builder.Services.AddSingleton < IExceptionHandler, UnauthorizedExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, ValidationExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, DatabaseExceptionHandler>();
builder.Services.AddSingleton<IExceptionHandler, DefaultExceptionHandler>();
builder.Services.AddHttpClient<SmsService>();
builder.Services.AddSingleton<IAmazonS3, AmazonS3Client>();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.Configure<ArvanStorageOptions>(
    builder.Configuration.GetSection("ArvanStorage")
);

builder.Services.Configure<OTPOptions>(
    builder.Configuration.GetSection("OTPOptions")
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Application starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    await Log.CloseAndFlushAsync();
}
