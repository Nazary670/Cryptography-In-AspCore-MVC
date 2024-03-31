using Cryptography.Domain.Entities;
using Cryptography.Domain.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Cryptography.Persistence.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    
}
    //The end.
}
