using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Persistence;

namespace ProductService.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)      // Eager load Category
                .Include(p => p.Franchise)     // Eager load Franchise
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Product>> SearchAsync(string? name, string? type, string? franchise)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Franchise)
                .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
                            (string.IsNullOrEmpty(franchise) || p.Franchise.Name.Contains(franchise)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string? name, string? franchise, string? category)
        {
             var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Franchise)
            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(franchise))
                query = query.Where(p => p.Franchise.Name == franchise);

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.Name == category);

            return await query.ToListAsync();
        }

        public async Task<List<Product>> GetByIdsAsync(List<int> productIds)
        {
            return await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }
    }
}
