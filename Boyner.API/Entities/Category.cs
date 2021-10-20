using Boyner.API.Entities.Abstract;
using Boyner.API.Entities.Base;
using System.Collections;
using System.Collections.Generic;

namespace Boyner.API.Entities
{
    public class Category:Entity, IAggreegateRoot
    {
        public string Name { get; protected set; }
        public virtual ICollection<Product>Products { get; protected set; }
    }
}
