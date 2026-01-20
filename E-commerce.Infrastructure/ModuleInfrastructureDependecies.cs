using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.InfrastructureBase;
using E_commerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace E_commerce.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) {

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IAddressRepository,AddressRepository>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IShoppingCartRepository,ShoppingCartRepository>();
            services.AddTransient<ICartItemRepository,CartItemRepository>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<IOrderItemRepository,OrderItemRepository>();
            services.AddTransient<ICustomerRepository,CustomerRepository>();

            return services;
        }

    }
}
