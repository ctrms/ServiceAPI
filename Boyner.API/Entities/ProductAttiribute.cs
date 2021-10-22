using Boyner.API.Entities.Base;

namespace Boyner.API.Entities
{
    public class ProductAttribute: Entity
    {
        public ProductAttribute()
        {

        }
        public ProductAttribute(CategoryAttribute categoryAttribute, string value)
        {
            CategoryAttribute = categoryAttribute;
            Value = value;
        }

        public virtual CategoryAttribute CategoryAttribute { get; protected set; }
        public string Value { get; protected set; }
        public virtual Product Product { get;protected set; }
    }
}
