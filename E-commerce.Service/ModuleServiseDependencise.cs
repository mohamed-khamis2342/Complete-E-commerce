
using E_commerce.Infrastructure.InfrastructureBase;
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
            return services;
        }

    }
}
