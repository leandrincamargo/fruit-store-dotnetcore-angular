using FruitStore.Domain.DTOs.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace FruitStore.Domain.Entities
{
    public class User : IIdentityEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public static explicit operator User(NewUserDto newUser)
        {
            return new User()
            {
                FirstName = newUser.FirstName,
                SecondName = newUser.SecondName,
                Email = newUser.Email,
                Password = newUser.Password,
                RoleId = newUser.RoleId,
                Status = newUser.Status
            };
        }
    }
}
