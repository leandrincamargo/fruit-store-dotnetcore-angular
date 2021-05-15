using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain.Standard;
using System;
using System.Linq.Expressions;

namespace FruitStore.Infrastructure.Interfaces.Repositories.Domain
{
    public interface IUserRepository : IDomainRepository<User>
    {
        Pagination<User> GetUsersWithPagination(Expression<Func<User, bool>> predicate, int pageNumber, int pageSize);
        User GetUserWithFilter(Expression<Func<User, bool>> predicate);
        bool ValidatePassword(string email, string password);
    }
}
