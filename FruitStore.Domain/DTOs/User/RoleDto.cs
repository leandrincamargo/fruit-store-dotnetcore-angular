using System;

namespace FruitStore.Domain.DTOs.User
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator RoleDto(Entities.Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
