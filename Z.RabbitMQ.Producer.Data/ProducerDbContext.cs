using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Producer.Domain.Models;

namespace Z.RabbitMQ.Producer.Data
{
    public class ProducerDbContext : DbContext
    {
        public ProducerDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey(e => e.Id);
            });
        }
    }
}