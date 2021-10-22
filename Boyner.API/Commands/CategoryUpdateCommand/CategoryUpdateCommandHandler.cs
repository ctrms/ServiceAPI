using Boyner.API.Entities;
using Boyner.API.Exceptions;
using Boyner.API.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Commands.CategoryUpdateCommand
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, int>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryUpdateCommandHandler(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetSingleAsync(request.Id);
            Argument.CheckIfNull(category, "category");

            category.UpdateName(request.Name);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
