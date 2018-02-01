using Microsoft.EntityFrameworkCore;

namespace DataStandard
{
    public class LocationsContext : DbContext
    {
        public LocationsContext() : base( )
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LocationsDev;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<State> State { get; set; }


    }
}
