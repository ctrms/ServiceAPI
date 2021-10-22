using FluentValidation;

namespace Boyner.API.Commands.ProductUpdateCommand
{
    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Ürün boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Ürün adı olamaz");

        }
    }
}
