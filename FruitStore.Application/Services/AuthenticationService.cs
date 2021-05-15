using FruitStore.Application.Interfaces.Services;
using FruitStore.Domain.DTOs.User;
using FruitStore.Domain.Entities;
using FruitStore.Infrastructure.Interfaces.Repositories.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FruitStore.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public AuthenticationService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public string Authenticate(UserLoginDto dto, out string error)
        {
            error = string.Empty;

            var hashPassword = _securityService.Encrypt(dto.Password, dto.Email);
            var user = _userRepository.GetUserWithFilter(user =>
                                        user.Email.ToLower().Equals(dto.Email.ToLower()) &&
                                        user.Password.ToLower().Equals(hashPassword));
            if (user == null)
            {
                error = "Email ou Senha inválido.";
                return null;
            }

            return GenerateToken(user);
        }

        private static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("64620a926ff863676225015795ee096944eb85452ffb2d48ffc194852ac2769f");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
