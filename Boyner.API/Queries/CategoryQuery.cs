using Boyner.API.Entities;
using Boyner.API.ModelDtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.API.Queries
{
    public class CategoryQuery : BaseQuery<Category>
    {
        public CategoryQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<CategoryListViewModel>> GetAll(string name, string attribute)
        {
            IQueryable<Category> categories = Query.Include(p => p.CategoryAttributes)
                            .Where(p => p.IsActive);

            if (!string.IsNullOrWhiteSpace(name))
            {
                categories = categories.Where(p => p.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(attribute))
            {
                categories = categories.Where(p => p.CategoryAttributes.Any(ca => ca.Name == attribute));
            }

            var category = await categories.Select(
                p => new CategoryListViewModel
                {
                    Name = p.Name,
                    CategoryAttributes = p.CategoryAttributes.Select(x => new CategoryAttributeViewModel { Name = x.Name }).ToList(),
                }).ToListAsync();

            return category;
        }
        public async Task<CategoryViewModel> GetById(int id)
        {
            var category = await Query.Include(p => p.Products)
               .
                FirstOrDefaultAsync(p => p.Id == id);
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Attributes = category.CategoryAttributes.Select(ca => new CategoryAttributeModelView
                {
                    Name = ca.Name
                }).ToList(),
            };
        }
    }
}
