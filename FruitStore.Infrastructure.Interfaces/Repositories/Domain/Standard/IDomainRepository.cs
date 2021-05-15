using FruitStore.Infrastructure.Interfaces.Repositories.Standard;

namespace FruitStore.Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepository<TEntity> where TEntity : class { }
}
