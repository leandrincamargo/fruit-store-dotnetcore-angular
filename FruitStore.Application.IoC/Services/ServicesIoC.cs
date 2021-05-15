using FruitStore.Application.Interfaces.Services;
using FruitStore.Application.Interfaces.Services.Standard;
using FruitStore.Application.Services;
using FruitStore.Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace FruitStore.Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFruitService, FruitService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
