using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Redis_Asp.net_Core_8.DataContext;
using Redis_Asp.net_Core_8.Repositories;
using Redis_Asp.net_Core_8.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
// Database Connection
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

// Redis Connection
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    option.InstanceName = "Hrm";
}
);

// Register Repository
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IRedisCache, RedisCacheService>();

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
