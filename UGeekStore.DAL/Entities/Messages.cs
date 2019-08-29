using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public class Messages : EntitiyBaseWithId
    {
        public int SenderID { get; set; }
        public int ReciverID { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReadDate { get; set; }

        public Users Users { get; set; }

    }
}
