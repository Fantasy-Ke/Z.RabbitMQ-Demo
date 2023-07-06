using Microsoft.AspNetCore.Mvc;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace RabbitMQ.Consumers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsConsumersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PersonsConsumersController> _logger;

        public PersonsConsumersController(ILogger<PersonsConsumersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}