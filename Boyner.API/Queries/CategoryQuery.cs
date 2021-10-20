using Boyner.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Boyner.API.Queries
{
    public class CategoryQuery : BaseQuery<Category>
    {
        public CategoryQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Category> GetByIdCategory(int id)
        {
            var category = await Query.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);
            return category;
        }
    }
}
