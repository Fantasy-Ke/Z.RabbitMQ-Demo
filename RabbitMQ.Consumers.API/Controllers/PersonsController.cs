using Microsoft.AspNetCore.Mvc;
using Z.RabbitMQ.Consumers.Application.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace RabbitMQ.Consumers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
       
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonsConsumersService _personsConsumersService;

        public PersonsController(ILogger<PersonsController> logger, IPersonsConsumersService personsConsumersService)
        {
            _logger = logger;
            _personsConsumersService = personsConsumersService;
        }

        [HttpGet(Name = "GetConsumersPersons")]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _personsConsumersService.GetConsumersPersons();
        }
    }
}