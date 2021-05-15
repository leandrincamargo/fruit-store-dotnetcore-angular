using FluentValidation;
using FruitStore.Domain.DTOs.User;

namespace FruitStore.Application.Validations
{
    public class UserLoginDtoValidation : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidation()
        {
            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("O Email é obrigatório")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("O Email está inválido");

            RuleFor(d => d.Password)
                .NotEmpty().WithMessage("A Senha é obrigatória");
        }
    }
}
