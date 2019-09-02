using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class Message : EntitiyBaseWithId
    {
        public int SenderId { get; set; }
        public int ReciverId { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? ReadTime { get; set; }
        public User Sender { get; set; }
        public User Reciver { get; set; }
    }
}
