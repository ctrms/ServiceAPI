using Boyner.API.Commands.ProductInsertCommand;
using Boyner.API.ModelDtos;
using Boyner.API.Results;
using System.Threading.Tasks;

namespace Boyner.API.Services
{
    public interface IProductService
    {
        Task<IDataResult<ProductViewModel>> GetAll();

        Task<IDataResult<int>> AddAsync(ProductInsertCommand productInsertCommand);
    }
}
