using Z.RabbitMQ.Domain.Core.Bus;
using Z.RabbitMQ.Producer.Application.Interfaces;
using Z.RabbitMQ.Producer.Domain.Commands;
using Z.RabbitMQ.Producer.Domain.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Application.Services
{
    public class PersonProducerService : IPersonsProducerService
    {
        private readonly IPersonProducerRepository _personRepository;
        private readonly IEventBasicBus _bus;

        public PersonProducerService(IPersonProducerRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task DeletePerson(int id)
        {
            var deleteEmployee = new DeletePersonCommand(id);
            await _bus.SendCommandsAsync(deleteEmployee);
        }

        public async Task<IEnumerable<Person>> GetConsumersPersons()
        {
            return await _personRepository.GetPersons();
        }

        public async Task<Person> GetPersonById(int Id)
        {
            return await _personRepository.GetPersonById(Id);
        }

        public async Task InsertPerson(Person employee)
        {
            var createNewPerson = new CreateNewPersonCommand(employee.Id,
                                                                 employee.FirstName,
                                                                 employee.LastName,
                                                                 employee.Age,
                                                                 employee.Salary);
            await _bus.SendCommandsAsync(createNewPerson);
        }

        public async Task UpdatePerson(int Id, Person employee)
        {
            var updatePerson = new UpdatePersonCommand(employee.Id,
                                                           employee.FirstName,
                                                           employee.LastName,
                                                           employee.Age,
                                                           employee.Salary);
            await _bus.SendCommandsAsync(updatePerson);
        }
    }
}
