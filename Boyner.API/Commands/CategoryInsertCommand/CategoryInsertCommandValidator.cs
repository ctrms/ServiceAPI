using FluentValidation;

namespace Boyner.API.Commands.CategoryInsertCommand
{
    public class CategoryInsertCommandValidator : AbstractValidator<CategoryInsertCommand>
    {
        public CategoryInsertCommandValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Kategori ismi boş olamaz");
        }
    }
}
