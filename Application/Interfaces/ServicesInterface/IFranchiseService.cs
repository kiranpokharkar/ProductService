using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IFranchiseService
    {
        /// <summary>
        /// Create a new Franchise
        /// </summary>
        /// <param name="franchiseDto"></param>
        /// <returns></returns>
        Task<FranchiseDto> CreateFranchisAsync(FranchiseDto franchiseDto);

        /// <summary>
        /// Get Franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FranchiseDto> GeFranchisByIdAsync(int id);

        /// <summary>
        /// Get all Franchises
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FranchiseDto>> GetAllFranchisAsync();

        /// <summary>
        /// Delete Franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteFranchiseAsync(int id);
    }
}
