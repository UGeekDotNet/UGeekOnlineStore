using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.ViewModels
{
    public class InvoicesModel
    {
        public string ShipAddres { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string UserPostalCode { get; set; }
        public string UserCountry { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderShippedDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public decimal  OrderPrice { get; set; }
    }
}
