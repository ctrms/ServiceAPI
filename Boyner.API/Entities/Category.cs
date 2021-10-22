using Boyner.API.Entities.Abstract;
using Boyner.API.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Boyner.API.Entities
{
    public class Category : AuditEntity, IAggreegateRoot
    {
        public string Name { get; protected set; }
        public virtual ICollection<Product> Products { get; protected set; }
        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; protected set; } = new List<CategoryAttribute>();

        public Category()
        {

        }
        public Category(string name)
        {
            Name = name;
        }

        internal void AddAttribute(string attr)
        {
            CategoryAttributes.Add(new CategoryAttribute(attr));
        }

        internal void UpdateName(string name)
        {
            Name = name;
        }
    }
}
