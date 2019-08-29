using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    class Products : EntitiyBaseWithId
    {
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string  ProductName { get; set; }
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return this._unitPrice; }
            set
            {
                if (value >= 0)
                    this._unitPrice = value;
                else
                    throw new Exception("Product price cannot be negative");
            }
        }
        private float _weight;
        public float Weight
        {
            get { return this._weight; }
            set
            {
                if (value > 0)
                    this._weight = value;
                else
                    throw new Exception("Product weight cannot be minus or zero");
            }
        }
        public string Description { get; set; }
        public string  AddedDate { get; set; }
        private int _count;
        public int Count
        {
            get { return this._count; }
            set
            {
                if (value >= 0)
                    this._count = value;
                else
                    throw new ArgumentNullException { };
            }
        }

        public Categories Categories { get; set; }




    }
}
