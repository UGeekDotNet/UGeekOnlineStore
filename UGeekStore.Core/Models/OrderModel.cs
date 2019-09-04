using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Models
{
    public class OrderModel
    {
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
