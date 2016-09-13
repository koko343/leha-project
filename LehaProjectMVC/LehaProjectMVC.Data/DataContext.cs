using LehaProjectMVC.Core.Interfaces;
using System.Data.Entity;
using LehaProjectMVC.Core.Entities;

namespace LehaProjectMVC.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("Connection")
        {
            //Database.SetInitializer(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(q => q.Id);
            modelBuilder.Entity<Cart>().ToTable("Carts").HasKey(q => q.Id);
            modelBuilder.Entity<CartItem>().ToTable("CartItems").HasKey(q => q.Id);
        }

        public System.Data.Entity.DbSet<LehaProjectMVC.Core.Entities.Product> Products { get; set; }
    }
}
