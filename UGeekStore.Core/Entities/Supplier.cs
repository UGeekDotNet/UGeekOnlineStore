using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
    public class Supplier : EntityBaseWithId
    {

        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
