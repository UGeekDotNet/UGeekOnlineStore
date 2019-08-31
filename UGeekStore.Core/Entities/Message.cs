using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
  public  class Message : EntityBaseWithId
    {
        public int SenderID { get; set; }
        public int ReciverID { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReadDate { get; set; }

        public User User { get; set; }
    }
}
