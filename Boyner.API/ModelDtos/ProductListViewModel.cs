namespace Boyner.API.ModelDtos
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool IsStock { get; set; }
        public string CategoryName { get; set; }
    }
}
