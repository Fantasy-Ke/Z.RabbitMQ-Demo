using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Consumers.Data;
using Z.RabbitMQ.Ioc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;
var services = builder.Services;


var connectionString = Configuration.GetConnectionString("ConsumersDbConnection");
services.AddDbContext<ConsumersDbContext>(options =>
{
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Z.RabbitMQ.Consumers.Data"));
});


DependencyContainer.RegisterServices(services);

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

