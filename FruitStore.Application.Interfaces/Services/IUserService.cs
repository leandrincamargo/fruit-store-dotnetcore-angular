using FruitStore.Application.Interfaces.Services.Standard;
using FruitStore.Domain.DTOs.User;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using System;

namespace FruitStore.Application.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        void Add(NewUserDto dto);
        void Update(Guid id, EditUserDto dto);
        void ChangeStatus(Guid id, bool status);
        Pagination<UserDto> GetNonActiveCommonUsers(int pageNumber, int pageSize);
    }
}
