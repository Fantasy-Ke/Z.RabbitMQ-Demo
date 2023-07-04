using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Z.RabbitMQ.Consumers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;

var Configuration = builder.Configuration;

var connectionString = Configuration.GetConnectionString("ConsumersDbConnection");
services.AddDbContext<ConsumersDbContext>(options =>
{
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Z.RabbitMQ.Consumers.Data"));
});

services.AddTransient<ConsumersDbContext>();

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
