using Microsoft.EntityFrameworkCore;
using Premium_Demo.DataAccess.Configuration;
using Premium_Demo.Domain;

namespace Premium_Demo.DataAccess
{
    public class OccupationDbContext : DbContext
    {
        public OccupationDbContext(DbContextOptions<OccupationDbContext> options) : base(options)
        { }

        public DbSet<Occupation> Occupations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OccupationConfiguration());
        }
    }
}
