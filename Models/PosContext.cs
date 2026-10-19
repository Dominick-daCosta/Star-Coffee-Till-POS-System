using Microsoft.EntityFrameworkCore;

namespace Starbucks_POS.Models
{
    public class PosContext : DbContext
    {
        // This will create the database according to the class "product"
        public DbSet<Product> Products { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<LmtdDrink> LmtdDrinks { get; set; }

        // This configures EF Core to create the SQLite file in your project directory
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source=starbucks_menu.db");
        }
    }
}