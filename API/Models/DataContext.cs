namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CatName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.Category);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustID)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderTables)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.ProdID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.CustID)
                .IsUnicode(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.ShippingMode)
                .IsUnicode(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.ShipDate)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProdID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderTables)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.Region1)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Region1)
                .HasForeignKey(e => e.Region);

            modelBuilder.Entity<Segment>()
                .Property(e => e.SegName)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.ShipMode)
                .IsUnicode(false);

            modelBuilder.Entity<Shipping>()
                .HasMany(e => e.OrderTables)
                .WithRequired(e => e.Shipping)
                .HasForeignKey(e => e.ShippingMode)
                .WillCascadeOnDelete(false);
        }
    }
}
