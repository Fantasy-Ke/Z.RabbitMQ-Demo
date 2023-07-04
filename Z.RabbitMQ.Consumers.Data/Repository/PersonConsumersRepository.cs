using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public Person GetPersonById(int Id)
        {
            return _context.Persons.Find(Id);
        }
    }
}
