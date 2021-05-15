using System;

namespace FruitStore.Domain.Entities
{
    public interface IIdentityEntity
    {
        Guid Id { get; set; }
    }
}
