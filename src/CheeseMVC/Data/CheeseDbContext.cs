using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        // Part 1 - Setting Up the New Model
        public DbSet<CheeseCategory> Categories { get; set; } // By naming this property Categories, EF will create a table within our database of the same name.

        // Part 3: Setting Up a Many-to-Many Relationship
        public DbSet<Menu>  Menus { get; set; }

        public DbSet<CheeseMenu> CheeseMenus { get; set; }

        // This method will set the primary key of the CheeseMenu class and table to be a composite key, consisting of both CheeseID and MenuID
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        { }

    }
}
