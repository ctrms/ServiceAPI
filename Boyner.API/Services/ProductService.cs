using Boyner.API.Commands.ProductInsertCommand;
using Boyner.API.CrossCuttingConcerns;
using Boyner.API.ModelDtos;
using Boyner.API.Queries;
using Boyner.API.Results;
using MediatR;
using System.Threading.Tasks;

namespace Boyner.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductQuery _productQuery;
        private readonly ICacheManager _cache;
        private readonly IMediator _mediator;
        public ProductService(ProductQuery productQuery, ICacheManager cache, IMediator mediator)
        {
            _productQuery = productQuery;
            _cache = cache;
            _mediator = mediator;
        }

        public async Task<IDataResult<int>> AddAsync(ProductInsertCommand productInsertCommand)
        {
            var result = await _mediator.Send(productInsertCommand);


            return new SuccessDataResult<int>(result);
        }

        public Task<IDataResult<ProductViewModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
