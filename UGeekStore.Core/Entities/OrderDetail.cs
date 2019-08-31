using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
   public class OrderDetail:EntityBase
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get
            {
                return this._unitPrice;

            }
            set
            {
                if (value >= 0)
                {
                    this._unitPrice = value;
                }
                else
                {
                    throw new Exception("Order Details UnitPrice Exeption");
                }
            }
        }
        private int  _quantity;
        public int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if (value >= 1)
                {
                    this._quantity = value;

                }
                else
                {
                    throw new Exception("OrderDetailsQuantity Exaption");
                }
            }
        }
        private float _discount;
        public float Discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                if (value >= 0)
                {
                    this._discount = value;
                }
                else
                {
                    throw new Exception("OrderDetails Disqount Exeption");
                }
            }
        }

        public Product Product { get; set; }
        public Order Order { get; set; }



    }
}
