using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Infrastructure.Persistence;
using ProductService.Infrastructure.Repository;
using ProductService.Application.Services;
using MongoDB.Driver;

namespace ProductService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFranchiseRepository, FranchiseRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IProductService, ProductServiceImpl>();
            services.AddScoped<IFranchiseService, FranchiseServiceImpl>();
            services.AddScoped<ICategoryService, CategoryServiceImpl>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
