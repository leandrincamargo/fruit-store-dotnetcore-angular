using FruitStore.Infrastructure.DBConfiguration;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using FruitStore.Infrastructure.Interfaces.Repositories.Standard;
using FruitStore.Infrastructure.Repositories;
using FruitStore.Infrastructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FruitStore.Infrastructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IFruitRepository, FruitRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
