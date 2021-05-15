using FluentValidation;
using FruitStore.Domain.DTOs.User;
using FruitStore.Domain.Utility;

namespace FruitStore.Application.Validations
{
    public class NewUserDtoValidation : AbstractValidator<NewUserDto>
    {
        public NewUserDtoValidation()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(100).WithMessage("Tamanho máximo do campo nome é de 100 caracteres");

            RuleFor(d => d.SecondName)
                .NotEmpty().WithMessage("O Sobrenome é obrigatório")
                .MaximumLength(100).WithMessage("Tamanho máximo do campo nome é de 100 caracteres");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("O Email é obrigatório")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("O Email está inválido");

            RuleFor(d => d.Password)
                .NotEmpty().WithMessage("A Senha é obrigatória");

            RuleFor(d => d.RoleId)
                .NotEmpty().WithMessage("O Id da Role é obrigatória")
                .Custom((id, context) =>
                {
                    if (id != RoleIdentify.Common.Id && id != RoleIdentify.Administrator.Id)
                        context.AddFailure("O Id da Role está incorreto");
                });

            RuleFor(d => d.Status)
                .NotNull().WithMessage("O Status é obrigatório");
        }
    }
}
