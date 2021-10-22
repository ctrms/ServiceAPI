namespace Boyner.API.ModelDtos
{
    using System.Collections.Generic;
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryAttributeModelView> Attributes { get; set; }
    }
    public class CategoryAttributeModelView
    {
        public string Name { get; set; }
    }
}
