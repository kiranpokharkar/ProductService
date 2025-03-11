using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Repository;

namespace ProductService.Application.Services
{
    public class FranchiseServiceImpl : IFranchiseService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;

        public FranchiseServiceImpl(IFranchiseRepository franchiseRepository, IMapper mapper)
        {
            _franchiseRepository = franchiseRepository;
            _mapper = mapper;

        }

        public async Task<FranchiseDto> CreateFranchisAsync(FranchiseDto franchiseDto)
        {
            if (franchiseDto == null)
            {
                throw new ArgumentNullException(nameof(franchiseDto));
            }

            var franchise = _mapper.Map<Franchise>(franchiseDto);
            await _franchiseRepository.AddAsync(franchise);

            // Return the newly created product as a DTO
            return _mapper.Map<FranchiseDto>(franchise);
        }

        public async Task<FranchiseDto> GeFranchisByIdAsync(int id)
        {
            var franchise = await _franchiseRepository.GetByIdAsync(id);

            if (franchise == null)
            {
                throw new KeyNotFoundException($"Franchise with id {id} not found.");
            }

            return _mapper.Map<FranchiseDto>(franchise);
        }


        public async Task<IEnumerable<FranchiseDto>> GetAllFranchisAsync()
        {
            var franchise = await _franchiseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FranchiseDto>>(franchise);
        }

        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _franchiseRepository.GetByIdAsync(id);
            if (franchise != null)
            {
                await _franchiseRepository.DeleteAsync(franchise);
            }
        }
    }
}
