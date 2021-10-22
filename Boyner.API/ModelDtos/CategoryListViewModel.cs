using System.Collections.Generic;

namespace Boyner.API.ModelDtos
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryAttributeViewModel> CategoryAttributes { get; set; }
    }

    public class CategoryAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
