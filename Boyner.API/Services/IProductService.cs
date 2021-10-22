using Boyner.API.Commands.ProductDeleteCommand;
using Boyner.API.Commands.ProductInsertCommand;
using Boyner.API.Commands.ProductUpdateCommand;
using Boyner.API.ModelDtos;
using Boyner.API.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boyner.API.Services
{
    public interface IProductService
    {
        Task<IDataResult<List<ProductListViewModel>>> GetAllAsync(
            string name,
            string categoryName,
            string attributeName,
            string attributeValue,
            decimal? priceStart,
            decimal? priceEnd);
        Task<IDataResult<ProductViewModel>> GetByIdAsync(int id);
        Task<IDataResult<int>> AddAsync(ProductInsertCommand productInsertCommand);
        Task<IDataResult<int>> UpdateAsync(ProductUpdateCommand productUpdateCommand);
        Task<IDataResult<int>> DeleteAsync(ProductDeleteCommand productDeleteCommand);
    }
}
