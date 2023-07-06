using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Producer.Domain.Interfaces;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Data.Repository
{
    public class PersonProducerRepository : IPersonProducerRepository
    {
        private readonly ProducerDbContext _context;

        public PersonProducerRepository(ProducerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int Id)
        {
            return await _context.Persons.FindAsync(Id);
        }
    }
}
