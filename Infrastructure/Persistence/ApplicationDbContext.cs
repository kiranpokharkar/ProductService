using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique(); // Ensures category names are unique
            base.OnModelCreating(modelBuilder);

            // Configuring the relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  // Each Product has one Category
                .WithMany(c => c.Products) // Each Category can have many Products
                .HasForeignKey(p => p.CategoryId) // Foreign Key in Product points to CategoryId
                .OnDelete(DeleteBehavior.Cascade); // Optionally, set the delete behavior (Cascade or Restrict)
        }
    }
}
