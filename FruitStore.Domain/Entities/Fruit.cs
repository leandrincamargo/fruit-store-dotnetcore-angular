using FruitStore.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace FruitStore.Domain.Entities
{
    public class Fruit : IIdentityEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }

        public static explicit operator Fruit(FruitDto request)
        {
            return new Fruit
            {
                Name = request.Name,
                Description = request.Description,
                PictureUrl = request.PictureUrl,
                StockAmount = request.StockAmount,
                Price = request.Price
            };
        }
    }
}
