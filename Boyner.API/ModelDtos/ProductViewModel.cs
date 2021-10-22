namespace Boyner.API.ModelDtos
{
    using System.Collections.Generic;
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public bool IsStock { get; set; }
        public List<ProductAttributeModelView> Attributes { get; set; }
    }
    public class ProductAttributeModelView
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
