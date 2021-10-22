using Boyner.API.Entities.Base;
using System;
using System.Collections.Generic;

namespace Boyner.API.Entities
{
    public class Product: AuditEntity, Abstract.IAggreegateRoot
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public bool IsStock { get; protected set; }
        public virtual Category Category { get; protected set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get;protected set; }=new List<ProductAttribute>();
        public Product()
        {

        }
        public Product(string name, bool stok, decimal price, Category category)
        {
            Name = name;
            IsStock = IsStock;
            Price = price;
            IsActive = true;
            Category = category;
        }

        internal void AddAttributes(CategoryAttribute categoryAttribute, string value)
        {
            ProductAttributes.Add(new ProductAttribute(categoryAttribute,value));
        }

        internal void UpdateName(string name)
        {
            Name = name;
        }
    }
}
