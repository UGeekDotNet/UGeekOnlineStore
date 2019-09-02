using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;
using UGeekStore.DAL.Entities;

namespace UGeekStore.Core.Entities
{
   public class Order : EntityBaseWithId
    {
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public User User { get; set; }
        public Shipper Shipper { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
