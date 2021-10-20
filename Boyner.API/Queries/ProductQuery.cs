using Boyner.API.Entities;
using Boyner.API.ModelDtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.API.Queries
{
    public class ProductQuery : BaseQuery<Product>
    {
        public ProductQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<ProductListViewModel>> GetAll()
        {
            var product = await Query.Include(p => p.Category).Where(p => p.IsActive).Select(
                p => new ProductListViewModel
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    Price = p.Price,
                    IsStock = p.IsStock
                }).ToListAsync();
            return product;
        }
        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await Query.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                IsActive = product.IsActive,
                IsStock = product.IsStock,
                Price = product.Price,
                CategoryId = product.Category.Id
            };
        }
    }
}
