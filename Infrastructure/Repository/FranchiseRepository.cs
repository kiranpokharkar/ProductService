using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Persistence;

namespace ProductService.Infrastructure.Repository
{
    public class FranchiseRepository : GenericRepository<Franchise>, IFranchiseRepository
    {
        private readonly ApplicationDbContext _context;

        public FranchiseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Searches for franchises by name or description.
        /// </summary>
        /// <param name="name">The name of the franchise to search for.</param>
        /// <param name="description">The description to search for within the franchise.</param>
        /// <returns>A collection of matching franchise entities.</returns>
        public async Task<IEnumerable<Franchise>> SearchAsync(string? name)
        {
            return await _context.Franchises
                .Where(f => (string.IsNullOrEmpty(name) || f.Name.Contains(name)))
                .ToListAsync();
        }
    }
}
