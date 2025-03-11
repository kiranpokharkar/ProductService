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
            // Map Product entity to ProductDto and vice versa
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Franchise, opt => opt.MapFrom(src => src.Franchise));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Franchise, opt => opt.MapFrom(src => src.Franchise));

            // Map Category entity to CategoryDto and vice versa
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            // Map Franchise entity to FranchiseDto and vice versa
            CreateMap<Franchise, FranchiseDto>();
            CreateMap<FranchiseDto, Franchise>();

            // Mapping for Cart
            CreateMap<Cart, CartDto>()
                       .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<CartDto, Cart>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId.ToString()));

            CreateMap<CartItemDto, CartItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => int.Parse(src.ProductId)));

        }
    }
}
