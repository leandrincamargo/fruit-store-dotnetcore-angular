using FruitStore.Application.Interfaces.Services;
using FruitStore.Application.Services.Standard;
using FruitStore.Domain.DTOs;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Enums;
using FruitStore.Domain.Utility;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using System;

namespace FruitStore.Application.Services
{
    public class FruitService : ServiceBase<Fruit>, IFruitService
    {
        private readonly IFruitRepository _repository;

        public FruitService(IFruitRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Guid Add(FruitDto request)
        {
            var fruit = (Fruit)request;
            var newFruit = base.Add(fruit);

            return newFruit.Id;
        }

        public void Update(Guid id, FruitDto request)
        {
            var fruit = base.GetById(id);
            fruit.Name = request.Name;
            fruit.Description = request.Description;
            fruit.PictureUrl = request.PictureUrl;
            fruit.StockAmount = request.StockAmount;
            fruit.Price = request.Price;

            base.Update(fruit);
        }

        public void ChangeAmount(Guid id, int operation, int amountValue)
        {
            var fruit = base.GetById(id);

            fruit.StockAmount = CalculateNewAmount(operation, fruit.StockAmount, amountValue);

            base.Update(fruit);
        }

        public Pagination<Fruit> Get(int pageNumber, int pageSize)
        {
            return _repository.GetFruitsWithPagination(null, pageNumber, pageSize);
        }

        public bool Delete(Guid id)
        {
            return base.Remove(id);
        }

        private static int CalculateNewAmount(int operation, int initialValue, int amountValue)
        {
            var newValue = initialValue;

            switch (operation)
            {
                case (int)OperationEnum.Plus:
                    newValue += amountValue;
                    break;
                case (int)OperationEnum.Minus:
                    newValue -= amountValue;
                    break;
                default:
                    break;
            }

            return newValue;
        }
    }
}
