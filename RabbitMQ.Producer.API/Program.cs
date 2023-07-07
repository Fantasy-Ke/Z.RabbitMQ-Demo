using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Z.RabbitMQ.Bus.Options;
using Z.RabbitMQ.Ioc;
using Z.RabbitMQ.Producer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services; 


var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("ProducerDbConnection");
services.AddDbContext<ProducerDbContext>(options =>
{
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Z.RabbitMQ.Producer.Data"));
});


services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

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

app.MapControllers();

app.Run();
