using Core.Application.Interfaces;
using Infrastructure.Services.Impementation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
