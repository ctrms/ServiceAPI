using Boyner.API.Commands.CategoryDeleteCommand;
using Boyner.API.Commands.CategoryInsertCommand;
using Boyner.API.Commands.CategoryUpdateCommand;
using Boyner.API.CrossCuttingConcerns;
using Boyner.API.CrossCuttingConcerns.Aspect;
using Boyner.API.ModelDtos;
using Boyner.API.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICacheManager _cache;
        private readonly IMediator _mediator;
        private readonly Queries.CategoryQuery _categoryQuery;
        public CategoryService( ICacheManager cache, IMediator mediator, Queries.CategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
            _cache = cache;
            _mediator = mediator;
        }

        [CacheRemoveAspect("ICategoryService.GetAll")]
        public async Task<IDataResult<int>> AddAsync(CategoryInsertCommand categoryInsertCommand)
        {
            var result = await _mediator.Send(categoryInsertCommand);
            return new SuccessDataResult<int>(result);
        }

        [CacheRemoveAspect("ICategoryService.GetAll")]
        public async Task<IDataResult<int>> DeleteAsync(CategoryDeleteCommand categoryDeleteCommand)
        {
            var result = await _mediator.Send(categoryDeleteCommand);
            return new SuccessDataResult<int>(result);
        }

        [CacheRemoveAspect("ICategoryService.GetAll")]
        public async Task<IDataResult<int>> UpdateAsync(CategoryUpdateCommand categoryUpdateCommand)
        {
            var result = await _mediator.Send(categoryUpdateCommand);
            return new SuccessDataResult<int>(result);
        }
        [CacheAspect(duration: 2)]
        public async Task<IDataResult<List<CategoryListViewModel>>> GetAllAsync(string name, string attribute)
        {
            var categories = await _categoryQuery.GetAll(name, attribute);
            return new SuccessDataResult<List<CategoryListViewModel>>(categories.Select(c => new CategoryListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                CategoryAttributes = c.CategoryAttributes.Select(a =>  new CategoryAttributeViewModel { Id = a.Id, Name = a.Name }).ToList()
            }).ToList()) ;
        }
    }
}
