using CustomerAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.DAL.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerDTO> Customer { get; set; }
    }
}
