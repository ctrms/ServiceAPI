using FluentValidation;

namespace Boyner.API.Commands.CategoryDeleteCommand
{
    public class CategoryDeleteCommandValidator : AbstractValidator<CategoryDeleteCommand>
    {
        public CategoryDeleteCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Kategori boş olamaz");
        }
    }
}
