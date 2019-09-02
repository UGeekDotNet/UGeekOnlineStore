using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
   public class Product:EntityBaseWithId
    {
        private float _weight;
        private decimal _unitPrice;
        private int _count;

        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice
        {
            get
            {
                return this._unitPrice;
            }
            set
            {
                if (value >= 0 )
                {
                    this._unitPrice = value;
                }
                else
                {
                    throw new Exception("Price must be whole number");
                }
            }
        }
        public float Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                if (value >= 0)
                {
                    this._weight = value;
                }
                else
                {
                    throw new Exception("Weight could be negative");
                }

            }
        }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public int  Count
        {
            get
            {
                return this._count;
            }
            set
            {
                if (value >= 0)
                {
                    this._count = value;
                }
                else
                {
                    throw new Exception("Count could be negative");
                }
            }
        }

        public Category Category { get; set; }
        public Supplier Suplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
