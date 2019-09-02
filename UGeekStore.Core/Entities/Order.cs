using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public  class Order : EntitiyBaseWithId
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
        public Shipper Shipper { get; set; }
    }
}
