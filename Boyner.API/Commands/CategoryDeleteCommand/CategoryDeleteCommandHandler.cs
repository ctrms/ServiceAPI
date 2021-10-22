using Boyner.API.Entities;
using Boyner.API.Exceptions;
using Boyner.API.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Commands.CategoryDeleteCommand
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, int>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryDeleteCommandHandler(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository
                .Include(p=>p.Products)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            Argument.CheckIfNull(category, "category");

            foreach (var product in category.Products)
            {
                product.SetPassive();
            }

            category.SetPassive();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
