using System;

namespace FruitStore.Domain.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public RoleDto Role { get; set; }

        public static explicit operator UserDto(Entities.User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                Status = user.Status,
                Role = (RoleDto)user.Role
            };
        }
    }
}
