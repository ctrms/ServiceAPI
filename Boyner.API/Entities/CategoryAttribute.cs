using Boyner.API.Entities.Base;
using System.Collections;
using System.Collections.Generic;

namespace Boyner.API.Entities
{
    public class CategoryAttribute: Entity
    {
        public CategoryAttribute()
        {

        }
        public CategoryAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        public virtual Category Category { get;protected set; }
        public ICollection<ProductAttribute> ProductAttributes { get;protected set; }
    }
}
