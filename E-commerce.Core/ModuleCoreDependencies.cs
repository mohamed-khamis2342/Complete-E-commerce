
using E_commerce.Auth;
using E_commerce.Infrastructure.AppContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.Reflection;

namespace E_commerce.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

           //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddIdentity<ApplicationUser, Role>()
              .AddEntityFrameworkStores<ApplicationDbContext>();


            return services;
        }
    }
}
