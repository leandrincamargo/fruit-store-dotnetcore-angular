using FluentValidation;
using FruitStore.Domain.DTOs.User;

namespace FruitStore.Application.Validations
{
    public class EditUserDtoValidation : AbstractValidator<EditUserDto>
    {
        public EditUserDtoValidation()
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
        }
    }
}
