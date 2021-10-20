namespace Boyner.API.ModelDtos
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Price { get; set; }
        public bool IsStock { get; set; }
    }
}
