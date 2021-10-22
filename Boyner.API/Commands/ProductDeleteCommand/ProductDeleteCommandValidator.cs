using FluentValidation;

namespace Boyner.API.Commands.ProductDeleteCommand
{
    public class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Ürün boş olamaz");
        }
    }
}
