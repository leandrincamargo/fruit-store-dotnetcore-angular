using System;

namespace FruitStore.Domain.DTOs.User
{
    public class EditUserDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
