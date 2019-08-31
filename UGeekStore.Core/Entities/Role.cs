using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
   public class Role : EntityBaseWithId
    {
        public string Name { get; set; }
        public bool? IsDefault { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
