using System.Data.Entity.Migrations;

namespace DataFramework
{
    public class EF6DBContextConfiguration : DbMigrationsConfiguration<EF6DBContext>
    {
        public EF6DBContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}