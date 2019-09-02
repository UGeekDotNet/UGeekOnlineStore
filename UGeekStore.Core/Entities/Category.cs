using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
    public class Category : EntityBaseWithId
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
