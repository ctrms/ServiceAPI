using Boyner.API.Entities.Base;

namespace Boyner.API.Entities
{
    public class Product: AuditEntity, Abstract.IAggreegateRoot
    {
        public string Name { get; protected set; }
        public string Price { get; protected set; }
        public bool IsStock { get; protected set; }
        public virtual Category Category { get; protected set; }
        public Product()
        {

        }
        public Product(string name, bool stok, string price, Category category)
        {
            Name = name;
            IsStock = IsStock;
            Price = price;
            IsActive = true;
            Category = category;
        }
    }
}
