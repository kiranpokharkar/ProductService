using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<ProductDto, Product>()
                        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)); // Directly map CategoryId

            // Map Product to ProductDto (CategoryId will be in the DTO, not the full Category object)
            CreateMap<Product, ProductDto>();
        }
    }
}
