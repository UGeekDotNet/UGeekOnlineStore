using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class Role : EntitiyBaseWithId
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
