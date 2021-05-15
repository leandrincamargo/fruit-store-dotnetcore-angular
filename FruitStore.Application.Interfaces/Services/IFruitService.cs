using FruitStore.Application.Interfaces.Services.Standard;
using FruitStore.Domain.DTOs;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Utility;
using System;

namespace FruitStore.Application.Interfaces.Services
{
    public interface IFruitService : IServiceBase<Fruit>
    {
        Guid Add(FruitDto request);
        void Update(Guid id, FruitDto request);
        void ChangeAmount(Guid id, int operation, int amountValue);
        Pagination<Fruit> Get(int pageNumber, int pageSize);
        bool Delete(Guid id);
    }
}
