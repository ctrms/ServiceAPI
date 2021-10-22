using Boyner.API.Commands.ProductDeleteCommand;
using Boyner.API.Commands.ProductInsertCommand;
using Boyner.API.Commands.ProductUpdateCommand;
using Boyner.API.ModelDtos;
using Boyner.API.Queries;
using Boyner.API.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(
            string name = null,
            string categoryName = null,
            string attributeName = null,
            string attributeValue = null,
            decimal? priceStart = null,
            decimal? priceEnd = null)
        {
            var result = await _productService.GetAllAsync(name, categoryName, attributeName, attributeValue, priceStart, priceEnd);
            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Insert(ProductInsertCommand productInsertCommand)
        {
            var result = await _productService.AddAsync(productInsertCommand);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateName(int id, ProductUpdateCommand productUpdateCommand)
        {
            productUpdateCommand.Id = id;

            var result = await _productService.UpdateAsync(productUpdateCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(new ProductDeleteCommand { Id = id });
            return Ok(result);
        }
    }
}
