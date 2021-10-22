using Boyner.API.Entities;
using Boyner.API.Exceptions;
using Boyner.API.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Commands.CategoryInsertCommand
{
    public class CategoryInsertCommandHandler : IRequestHandler<CategoryInsertCommand, int>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Queries.CategoryQuery _categoryQuery;
        public CategoryInsertCommandHandler(IRepository<Category> categoryRepository, Queries.CategoryQuery categoryQuery, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _categoryQuery = categoryQuery;
        }

        public async Task<int> Handle(CategoryInsertCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            foreach (var attr in request.Attributes)
                category.AddAttribute(attr);
            await _categoryRepository.MarkForInsertionAsync(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Id;

        }
    }
}
