using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IFranchiseService
    {
        Task<FranchiseDto> CreateFranchisAsync(FranchiseDto franchiseDto);
        Task<FranchiseDto> GeFranchisByIdAsync(int id);
        Task<IEnumerable<FranchiseDto>> GetAllFranchisAsync();

        Task DeleteFranchiseAsync(int id);
    }
}
