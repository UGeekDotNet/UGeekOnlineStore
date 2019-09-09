using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int SenderID { get; set; }
        public int ReciverID { get; set; }
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? ReadDate { get; set; }
    }
}
