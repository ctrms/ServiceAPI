using Boyner.API.Entities;
using Boyner.API.Exceptions;
using Boyner.API.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Commands.ProductInsertCommand
{
    public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, int>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Queries.CategoryQuery _categoryQuery;
        public ProductInsertCommandHandler(IRepository<Product> productRepository, Queries.CategoryQuery categoryQuery, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryQuery = categoryQuery;
        }

        public async Task<int> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryQuery.FindAsync(request.CategoryId);
            Argument.CheckIfNull(category, "category");

            var product = new Product(request.Name, request.IsStock, request.Price, category);
            await _productRepository.MarkForInsertionAsync(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;

        }
    }
}
