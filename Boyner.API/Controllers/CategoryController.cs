using Boyner.API.Commands.CategoryDeleteCommand;
using Boyner.API.Commands.CategoryInsertCommand;
using Boyner.API.Commands.CategoryUpdateCommand;
using Boyner.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boyner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(string name = null, string attribute = null)
        {
            var result = await _categoryService.GetAllAsync(name, attribute);
            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Insert(CategoryInsertCommand categoryInsertCommand)
        {
            var result = await _categoryService.AddAsync(categoryInsertCommand);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateName(int id, CategoryUpdateCommand categoryUpdateCommand)
        {
            categoryUpdateCommand.Id = id;
            var result = await _categoryService.UpdateAsync(categoryUpdateCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(new CategoryDeleteCommand { Id = id });
            return Ok(result);
        }
    }
}
