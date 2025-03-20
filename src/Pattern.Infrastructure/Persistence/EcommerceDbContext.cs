using Microsoft.EntityFrameworkCore;
using Pattern.Domain.Entities;

namespace Pattern.Infrastructure.Persistence
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }

        // DbSets for tables
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints

            // Order -> User (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // OrderDetail -> Order (Many-to-One)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // OrderDetail -> Product (Many-to-One)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            // Shipment -> Order (One-to-One)
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Order)
                .WithOne(o => o.Shipment)
                .HasForeignKey<Shipment>(s => s.OrderId);

            // ShipmentDetail -> Shipment (Many-to-One)
            modelBuilder.Entity<ShipmentDetail>()
                .HasOne(sd => sd.Shipment)
                .WithMany(s => s.ShipmentDetails)
                .HasForeignKey(sd => sd.ShipmentId);

            // ShipmentDetail -> Product (Many-to-One)
            modelBuilder.Entity<ShipmentDetail>()
                .HasOne(sd => sd.Product)
                .WithMany(p => p.ShipmentDetails)
                .HasForeignKey(sd => sd.ProductId);
        }
    }
}