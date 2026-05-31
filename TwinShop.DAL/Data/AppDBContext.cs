using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Entities;

namespace TwinShop.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<OTP> OTPs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BrandCategory>()
                .HasKey(b => new { b.BrandId, b.CategoryId });

            modelBuilder.Entity<BrandCategory>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.BrandCategories)
                .HasForeignKey(bc => bc.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BrandCategory>()
             .HasOne(bc => bc.Category)
             .WithMany(b => b.BrandCategories)
             .HasForeignKey(bc => bc.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.Category)
               .WithMany(p => p.Products)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
        }


    }
}