using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain.IService;
using Products.Infrastructure.Context;
using Products.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment Environment = builder.Environment;

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<NightDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
