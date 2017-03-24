using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EStore.Models;

namespace EStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Cart>()
                    .HasMany<CartItem>(s => s.Items)
                    .WithOne(s => s.Cart)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne<ApplicationUser>(s => s.User);

            builder.Entity<Order>()
                .HasMany<OrderItem>(s => s.Items)
                .WithOne(s => s.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasOne<Category>(s => s.Category)
                .WithMany(s => s.Products)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasOne(p => p.Cart)
                .WithOne(i => i.User)
                .HasForeignKey<Cart>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany<Order>(s => s.Orders)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
