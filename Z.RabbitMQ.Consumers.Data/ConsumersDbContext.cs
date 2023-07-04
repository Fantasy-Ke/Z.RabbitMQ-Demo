using Microsoft.EntityFrameworkCore;
using Z.RabbitMQ.Consumers.Domain.Models;

namespace Z.RabbitMQ.Consumers.Data
{
    public class ConsumersDbContext : DbContext
    {
        public ConsumersDbContext(DbContextOptions options) : base(options)
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