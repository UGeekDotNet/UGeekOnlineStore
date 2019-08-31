using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Infrastructre.EntityAbstraction
{
    public class EntityBaseWithId : EntityBase
    {
        public int Id { get; set; }
    }
}
