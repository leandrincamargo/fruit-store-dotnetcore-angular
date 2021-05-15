using FruitStore.Application.Interfaces.Services;
using FruitStore.Application.Services.Standard;
using FruitStore.Domain.DTOs.User;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using System;
using System.Linq;

namespace FruitStore.Application.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository repository, ISecurityService securityService) : base(repository)
        {
            _repository = repository;
            _securityService = securityService;
        }

        public void Add(NewUserDto dto)
        {
            var newUser = (User)dto;
            newUser.Password = _securityService.Encrypt(newUser.Password, newUser.Email);
            base.Add(newUser);
        }

        public void Update(Guid id, EditUserDto dto)
        {
            var user = base.GetById(id);
            user.FirstName = dto.FirstName;
            user.SecondName = dto.SecondName;
            user.Email = dto.Email;
            user.Password = !string.IsNullOrWhiteSpace(dto.Password) ? _securityService.Encrypt(dto.Password, dto.Email) : user.Password;

            base.Update(user);
        }

        public void ChangeStatus(Guid id, bool status)
        {
            var user = base.GetById(id);
            user.Status = status;
            base.Update(user);
        }

        public Pagination<UserDto> GetNonActiveCommonUsers(int pageNumber, int pageSize)
        {
            var paginationUser = _repository.GetUsersWithPagination(x => x.RoleId == RoleIdentify.Common.Id && x.Status, pageNumber, pageSize);
            var paginationUserDto = new Pagination<UserDto>(paginationUser.Items.Select(x => (UserDto)x), paginationUser.TotalItemCount, paginationUser.PageSize, paginationUser.CurrentPage);
            return paginationUserDto;
        }
    }
}
