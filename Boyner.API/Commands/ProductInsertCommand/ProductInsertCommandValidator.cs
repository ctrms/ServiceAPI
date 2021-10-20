using FluentValidation;

namespace Boyner.API.Commands.ProductInsertCommand
{
    public class ProductInsertCommandValidator : AbstractValidator<ProductInsertCommand>
    {
        public ProductInsertCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Ürün ismi boş olamaz");
        }
    }
}
