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

        public async Task<IEnumerable<Product>> SearchAsync(string? name, string? type, string? franchise)
        {
            return await _context.Products
                .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
                            (string.IsNullOrEmpty(type) || p.Type == type)
                            )
                .ToListAsync();
        }
    }
}
