using FruitStore.Application.Interfaces.Services.Standard;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain.Standard;
using System.Collections.Generic;

namespace FruitStore.Application.Services.Standard
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IDomainRepository<TEntity> repository;

        public ServiceBase(IDomainRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual TEntity Add(TEntity obj)
        {
            return repository.Add(obj);
        }

        public virtual void AddRange(IEnumerable<TEntity> obj)
        {
            repository.AddRange(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual TEntity GetById(object id)
        {
            return repository.GetById(id);
        }

        public virtual bool Remove(object id)
        {
            return repository.Remove(id);
        }

        public virtual void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
