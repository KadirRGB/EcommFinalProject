using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: DB tabloları ile proje class larını bağlamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string->Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS01;Database=Northwind;Trusted_Connection=True;");
            //optionsBuilder.UseNpgsql("Host=localhost;Database=northwind;Username=postgres;Password=root");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

/*
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //modelBuilder.HasDefaultSchema("dto");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().Property(p=>p.ProductId).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(p=>p.ProductName).HasColumnName("ProductName");
        }
*/

    } 
}