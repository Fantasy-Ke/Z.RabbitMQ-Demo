using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Consumers.Data.Data;
using Z.RabbitMQ.Consumers.Domain.Interfaces;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Data.Repository
{
    public class PersonConsumersRepository : IPersonConsumersRepository
    {
        private readonly ConsumersDbContext _context;

        public PersonConsumersRepository(ConsumersDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Person>> GetProducerEmployees()
        {
            throw new NotImplementedException();
        }

        public async Task ProducerDeletePerson(int id)
        {
            var employee = _context.Persons.FirstOrDefault(m => m.Id == id);
            _context.Persons.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task ProducerInsertPerson(Person employee)
        {
            _context.Add(employee);
           await _context.SaveChangesAsync();
        }

        public async Task ProducerUpdatePerson(int Id, Person employee)
        {
            _context.Update(employee);
           await  _context.SaveChangesAsync();
        }
    }
}
