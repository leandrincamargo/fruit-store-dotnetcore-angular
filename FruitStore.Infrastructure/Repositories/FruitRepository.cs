using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using FruitStore.Infrastructure.DBConfiguration;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using FruitStore.Infrastructure.Repositories.Standard;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Repositories
{
    public class FruitRepository : DomainRepository<Fruit>, IFruitRepository
    {
        public FruitRepository(ApplicationContext dbContext) : base(dbContext) { }

        public Pagination<Fruit> GetFruitsWithPagination(int pageNumber, int pageSize)
        {
            IQueryable<Fruit> query = _dbSet.OrderBy(x => x.Name);

            var skipNumber = Pagination<Fruit>.CalculateSkipNumber(pageNumber, pageSize);
            var totalItemCount = query.Count();
            var fruits = query.Skip(skipNumber).Take(pageSize).ToList();

            return new Pagination<Fruit>
            (
                items: fruits,
                totalItemCount: totalItemCount,
                pageSize: pageSize,
                currentPage: pageNumber
            );
        }
    }
}
