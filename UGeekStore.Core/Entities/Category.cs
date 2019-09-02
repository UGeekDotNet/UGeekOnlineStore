using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class Category : EntitiyBaseWithId
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
