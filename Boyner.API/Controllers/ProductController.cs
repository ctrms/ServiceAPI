using Boyner.API.Commands.ProductInsertCommand;
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

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> InsertProductToCart(ProductInsertCommand productInsertCommand)
        {
            var result = await _productService.AddAsync(productInsertCommand);
            return Ok(result);
        }

        [HttpGet]
        [Route("ListProducts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }
    }
}
