using FruitStore.Domain.Entities;
using FruitStore.Infrastructure.DBConfiguration;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using FruitStore.Infrastructure.Repositories.Standard;

namespace FruitStore.Infrastructure.Repositories
{
    public class RoleRepository : DomainRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
