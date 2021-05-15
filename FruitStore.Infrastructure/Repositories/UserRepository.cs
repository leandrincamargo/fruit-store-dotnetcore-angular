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
    public class UserRepository : DomainRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext) { }

        public Pagination<User> GetUsersWithPagination(Expression<Func<User, bool>> predicate, int pageNumber, int pageSize)
        {
            IQueryable<User> query = _dbSet.Where(predicate).OrderBy(x => x.FirstName);

            var skipNumber = Pagination<User>.CalculateSkipNumber(pageNumber, pageSize);
            var totalItemCount = query.Count();
            var users = query.Skip(skipNumber).Take(pageSize).ToList();

            return new Pagination<User>
            (
                items: users,
                totalItemCount: totalItemCount,
                pageSize: pageSize,
                currentPage: pageNumber
            );
        }

        public User GetUserWithFilter(Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> query = _dbSet.Where(predicate).OrderBy(x => x.FirstName);
            var user = query.FirstOrDefault();

            return user;
        }

        public bool ValidatePassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            return _dbSet.Any(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.Equals(password));
        }
    }
}
