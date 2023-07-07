using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Bus.Options;
using Z.RabbitMQ.Consumers.Data;
using Z.RabbitMQ.Ioc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var services = builder.Services;


var connectionString = configuration.GetConnectionString("ConsumersDbConnection");
services.AddDbContext<ConsumersDbContext>(options =>
{
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Z.RabbitMQ.Consumers.Data"));
});

var rabbitOption = new RabbitMQOptions();
configuration.GetSection("RabbitMQOptions").Bind(rabbitOption);

DependencyContainer.RegisterServices(services, rabbitOption);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureEventBus();

app.MapControllers();

app.Run();

