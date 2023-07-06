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

        public Task<IEnumerable<Person>> GetConsumersPersons()
        {
            throw new NotImplementedException();
        }

        public async Task ConsumersDeletePerson(int id)
        {
            var employee = _context.Persons.FirstOrDefault(m => m.Id == id);
            _context.Persons.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task ConsumersInsertPerson(Person employee)
        {
            _context.Add(employee);
           await _context.SaveChangesAsync();
        }

        public async Task ConsumersUpdatePerson(int Id, Person employee)
        {
            _context.Update(employee);
           await  _context.SaveChangesAsync();
        }
    }
}
