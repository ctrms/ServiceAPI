using Boyner.API.Commands.CategoryDeleteCommand;
using Boyner.API.Commands.CategoryInsertCommand;
using Boyner.API.Commands.CategoryUpdateCommand;
using Boyner.API.ModelDtos;
using Boyner.API.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boyner.API.Services
{
    public interface ICategoryService
    {
        Task<IDataResult<List<CategoryListViewModel>>> GetAllAsync(string name, string attribute);
        Task<IDataResult<int>> AddAsync(CategoryInsertCommand categoryInsertCommand);
        Task<IDataResult<int>> UpdateAsync(CategoryUpdateCommand categoryUpdateCommand);
        Task<IDataResult<int>> DeleteAsync(CategoryDeleteCommand categoryDeleteCommand);

    }
}
