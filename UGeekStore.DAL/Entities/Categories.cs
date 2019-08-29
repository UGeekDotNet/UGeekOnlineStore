using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    class Categories : EntitiyBaseWithId
    {
        public string  CategoryName { get; set; }

        public ICollection<Products> Products{ get; set; }

    }
}
