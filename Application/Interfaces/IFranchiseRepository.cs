using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IFranchiseRepository : IGenericRepository<Franchise>
    {
        /// <summary>
        /// Searches for franchises by name or description.
        /// </summary>
        /// <param name="name">The name of the franchise to search for.</param>
        /// <param name="description">The description to search for within the franchise.</param>
        /// <returns>A collection of matching franchise entities.</returns>
        Task<IEnumerable<Franchise>> SearchAsync(string? name);
    }
}
