using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public class Suppliers : EntitiyBaseWithId
    {
        public string  CompanyName { get; set; }

        public string  Adress { get; set; }
        public string  City { get; set; }
        public string  Country { get; set; }
        public bool  Status { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
