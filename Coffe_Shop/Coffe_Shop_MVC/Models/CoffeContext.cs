using Microsoft.EntityFrameworkCore;

namespace Coffe_Shop_MVC.Models
{
    public class CoffeContext : DbContext
    {
        public CoffeContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order_Item> Order_Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api
            modelBuilder.Entity<Order_Item>().HasKey("Order_Id","Item_Id");
            //modelBuilder.Entity<Cheque>().
                
        }
    }
}
