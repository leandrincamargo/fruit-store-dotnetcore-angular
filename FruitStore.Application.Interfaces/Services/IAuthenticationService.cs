using FruitStore.Domain.DTOs.User;

namespace FruitStore.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string Authenticate(UserLoginDto dto, out string error);
    }
}
