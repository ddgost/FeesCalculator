using System.Data.Entity;
using FeesCalculator.Migrations;

namespace FeesCalculator.Model
{
    public class AppContext : DbContext
    {
        public AppContext(): base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Configuration>());
        }
        public  DbSet<Utility> Utilities{ get; set; }
        public  DbSet<MonthlyConsumption> MonthlyConsumptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utility>().Property(e => e.Value).HasPrecision(18, 4);
        }

    }
}
