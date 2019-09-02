using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public  class OrderDetail : EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice
        {
            get { return UnitPrice; }
            set
            {
                if (value >= 0)
                {
                    UnitPrice = value;
                }
            }
        }
        public int Quantity
        {
            get { return Quantity; }
            set
            {
                if (value >= 1)
                {
                    Quantity = value;
                }
            }
        }
        public double Discount
        {
            get { return Discount; }
            set
            {
                if (value >= 0)
                {
                    Discount = value;
                }
            }
        }
        public Product Product { get; set; }
        public Order Order { get; set; } 
    }
}
