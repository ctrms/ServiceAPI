using Boyner.API.Commands.ProductDeleteCommand;
using Boyner.API.Commands.ProductInsertCommand;
using Boyner.API.Commands.ProductUpdateCommand;
using Boyner.API.CrossCuttingConcerns;
using Boyner.API.CrossCuttingConcerns.Aspect;
using Boyner.API.ModelDtos;
using Boyner.API.Queries;
using Boyner.API.Results;
using MediatR;
using System.Collections.Generic;
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
        [CacheAspect(duration: 2)]
        public async Task<IDataResult<List<ProductListViewModel>>> GetAllAsync(string name,
            string categoryName,
            string attributeName,
            string attributeValue,
            decimal? priceStart,
            decimal? priceEnd)
        {
            var result = await _productQuery.GetAll(name, categoryName, attributeName, attributeValue, priceStart, priceEnd);
            return new SuccessDataResult<List<ProductListViewModel>>(result);
        }
        [CacheRemoveAspect("IProductService.GetById")]
        public async Task<IDataResult<ProductViewModel>> GetByIdAsync(int id)
        {
            var result = await _productQuery.GetById(id);
            return new SuccessDataResult<ProductViewModel>(result);
        }

        [CacheRemoveAspect("IProductService.GetAll")]
        public async Task<IDataResult<int>> AddAsync(ProductInsertCommand productInsertCommand)
        {
            var result = await _mediator.Send(productInsertCommand);
            return new SuccessDataResult<int>(result);
        }

        [CacheRemoveAspect("IProductService.GetAll")]
        public async Task<IDataResult<int>> DeleteAsync(ProductDeleteCommand productDeleteCommand)
        {
            var result = await _mediator.Send(productDeleteCommand);
            return new SuccessDataResult<int>(result);
        }

        [CacheRemoveAspect("IProductService.GetAll")]
        public async Task<IDataResult<int>> UpdateAsync(ProductUpdateCommand productUpdateCommand)
        {
            var result = await _mediator.Send(productUpdateCommand);
            return new SuccessDataResult<int>(result);
        }
    }
}
