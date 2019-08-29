using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public class Rolies : EntitiyBaseWithId
    {
        public string RoleName { get; set; }
        public bool? IsDefault { get; set; }

        public ICollection<Users>Users { get; set; }
    }
}
