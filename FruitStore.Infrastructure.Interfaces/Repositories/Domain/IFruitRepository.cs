using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain.Standard;
using System;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Interfaces.Repositories.Domain
{
    public interface IFruitRepository : IDomainRepository<Fruit>
    {
        Pagination<Fruit> GetFruitsWithPagination(int pageNumber, int pageSize);
    }
}
