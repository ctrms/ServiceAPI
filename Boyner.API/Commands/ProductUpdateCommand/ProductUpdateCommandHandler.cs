using Boyner.API.Entities;
using Boyner.API.Exceptions;
using Boyner.API.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.API.Commands.ProductUpdateCommand
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, int>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductUpdateCommandHandler(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetSingleAsync(request.Id);
            Argument.CheckIfNull(product, "product");

            product.UpdateName(request.Name);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
