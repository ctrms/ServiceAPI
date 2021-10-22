using System.Collections.Generic;

namespace Boyner.API.ModelDtos
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsStock { get; set; }
        public string CategoryName { get; set; }
        public List<ProductAttributeViewModel> ProductAttributes { get; set; }
    }
    public class ProductAttributeViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public CaetgoryAttributeViewModel CaetgoryAttribute { get; set; }
    }
    public class CaetgoryAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
