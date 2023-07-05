using Microsoft.AspNetCore.Mvc;
using Z.RabbitMQ.Producer.Application.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace RabbitMQ.Producer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
       
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonsProducerService _personsConsumersService;

        public PersonsController(ILogger<PersonsController> logger, IPersonsProducerService personsConsumersService)
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