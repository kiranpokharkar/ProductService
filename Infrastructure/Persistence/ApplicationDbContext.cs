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
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure category names are unique
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Configure relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // Each Product has one Category
                .WithMany(c => c.Products) // Each Category can have many Products
                .HasForeignKey(p => p.CategoryId) // Foreign Key in Product points to CategoryId
                .OnDelete(DeleteBehavior.Cascade); // On deletion of Category, delete associated Products

            // Configure relationship between Product and Franchise
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Franchise) // Each Product has one Franchise
                .WithMany(f => f.Products) // Each Franchise can have many Products
                .HasForeignKey(p => p.FranchiseId) // Foreign Key in Product points to FranchiseId
                .OnDelete(DeleteBehavior.Cascade); // Optionally, set the delete behavior (Cascade or Restrict)

            // Ensure franchise names are unique
            modelBuilder.Entity<Franchise>()
                .HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}
