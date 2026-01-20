
using E_commerce.Infrastructure.InfrastructureBase;
using E_commerce.Infrastructure.Repository;
using E_commerce.Service.Abstracts;
using E_commerce.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {


            services.AddTransient<IAddressService,AddressService>();
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<IproductService,ProductService>();
            services.AddTransient<IShoppingCartService,ShoppingCartService>();
            services.AddTransient<ICartItemService,CartitemService>();
            services.AddTransient<IOrderService,OrderService>();

            services.AddTransient<ICustomerService,CustomerService>();

            return services;
        }

    }
}
