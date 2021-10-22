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
        public async Task<List<ProductListViewModel>> GetAll(
            string name,
            string categoryName,
            string attributeName,
            string attributeValue,
            decimal? priceStart,
            decimal? priceEnd)
        {
            IQueryable<Product> products = Query.Include(p => p.Category)
                            .Include(p => p.ProductAttributes).ThenInclude(p => p.CategoryAttribute)
                            .Where(p => p.IsActive);

            if (name != null)
                products = products.Where(p => p.Name == name);

            if (categoryName != null)
                products = products.Where(p => p.Category.Name == categoryName);

            if (attributeName != null && attributeValue != null)
                products = products.Where(a => a.ProductAttributes.Any(a => a.Value == attributeValue && a.CategoryAttribute.Name == attributeName));

            if (priceStart != null)
                products = products.Where(p => p.Price >= priceStart);

            if (priceEnd != null)
                products = products.Where(p => p.Price <= priceEnd);

            var product = await products.Select(
                p => new ProductListViewModel
                {
                    Name = p.Name,
                    CategoryName = p.Category.Name,
                    Price = p.Price,
                    IsStock = p.IsStock,
                    ProductAttributes = p.ProductAttributes.Select(pa => new ProductAttributeViewModel
                    {
                        Value = pa.Value,
                        CaetgoryAttribute = new CaetgoryAttributeViewModel
                        {
                            Name = pa.CategoryAttribute.Name
                        }
                    }).ToList()
                }).ToListAsync();
            return product;
        }
        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await Query.Include(p => p.Category)
               . FirstOrDefaultAsync(p => p.Id == id);
            return new ProductViewModel
            {
                Name = product.Name,
                IsActive = product.IsActive,
                IsStock = product.IsStock,
                Price = product.Price,
                CategoryId = product.Category.Id
            };
        }
      
    }
}
