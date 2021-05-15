using FluentValidation;
using FruitStore.Domain.DTOs;

namespace FruitStore.Application.Validations
{
    public class FruitDtoValidation : AbstractValidator<FruitDto>
    {
        public FruitDtoValidation()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(200).WithMessage("Tamanho máximo do campo nome é de 200 caracteres");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("A Descrição é obrigatória")
                .MaximumLength(500).WithMessage("Tamanho máximo do campo nome é de 500 caracteres");

            RuleFor(d => d.PictureUrl).NotEmpty().WithMessage("A Imagem é obrigatória");

            RuleFor(d => d.StockAmount).GreaterThanOrEqualTo(0).WithMessage("A Quantidade em Estoque é obrigatório");

            RuleFor(d => d.Price).GreaterThanOrEqualTo(0).WithMessage("O Preço é obrigatório");
        }
    }
}
