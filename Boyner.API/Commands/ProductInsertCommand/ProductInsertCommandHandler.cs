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
        private readonly Queries.CategoryAttributeQuery _categoryAttributeQuery;

        public ProductInsertCommandHandler(IRepository<Product> productRepository,
            Queries.CategoryQuery categoryQuery, IUnitOfWork unitOfWork, Queries.CategoryAttributeQuery categoryAttributeQuery)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryQuery = categoryQuery;
            _categoryAttributeQuery = categoryAttributeQuery;
        }

        public async Task<int> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryQuery.FindAsync(request.CategoryId);
            Argument.CheckIfNull(category, "category");
            var product = new Product(request.Name, request.IsStock, request.Price, category);
            foreach (var item in request.Attributes)
            {
                var categoryAttribute = await _categoryAttributeQuery.GetById(item.CategoryAttributeId);
                if (categoryAttribute.Category != category)
                    Argument.ThrowWorkflowException("Secilen kategori ve attributeleleri eşleşmiyor");
                product.AddAttributes(categoryAttribute,item.Value);
            }
            await _productRepository.MarkForInsertionAsync(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;

        }
    }
}
