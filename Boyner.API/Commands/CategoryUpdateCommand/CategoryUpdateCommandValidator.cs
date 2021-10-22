using FluentValidation;

namespace Boyner.API.Commands.CategoryUpdateCommand
{
    public class CategoryUpdateCommandValidator : AbstractValidator<CategoryUpdateCommand>
    {
        public CategoryUpdateCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Kategori boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Kategori adı boş olamaz");
        }
    }
}
