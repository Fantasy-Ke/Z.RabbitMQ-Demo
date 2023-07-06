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
        private readonly IPersonsProducerService _personsProducerService;

        public PersonsController(ILogger<PersonsController> logger, IPersonsProducerService personsProducerService)
        {
            _logger = logger;
            _personsProducerService = personsProducerService;
        }

        [HttpGet(Name = "GetConsumersPersons")]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _personsProducerService.GetConsumersPersons();
        }
        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Person> Get(int id)
        {
            return Ok(_personsProducerService.GetPersonById(id));
        }

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person employee)
        {
            try
            {
                await _personsProducerService.InsertPerson(employee);
                return Ok("New Person Saved Request Sent Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin. Error Message: " + ex.Message);
            }

        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person employee)
        {
            try
            {
                await _personsProducerService.UpdatePerson(id, employee);
                return Ok("Update Person Request Sent Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin. Error Message: " + ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personsProducerService.DeletePerson(id);
                return Ok("Delete Person Request Sent Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Request not done. Please contact Admin. Error Message: " + ex.Message);
            }
        }
    }
}