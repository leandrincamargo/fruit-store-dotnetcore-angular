using FruitStore.Infrastructure.DBConfiguration;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain.Standard;

namespace FruitStore.Infrastructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : Repository<TEntity>, IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
