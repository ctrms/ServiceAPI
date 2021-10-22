using Boyner.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boyner.API.Queries
{
    public class CategoryAttributeQuery : BaseQuery<CategoryAttribute>
    {
        public CategoryAttributeQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<CategoryAttribute> GetById(int id)
        {
            var categoryAttribute = await Query.Include(p => p.ProductAttributes)
                .Include(p=>p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            return categoryAttribute;
        }
    }
}
