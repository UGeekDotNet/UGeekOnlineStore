using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
   public  class Product : EntitiyBaseWithId
    {
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
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
        public double Weight
        {
            get { return Weight; }
            set
            {
                if (value >= 0)
                {
                    Weight = value;
                }
            }
        }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public int Count
        {
            get { return Count; }
            set
            {
                if (value >= 0)
                {
                    Count = value;
                }
            }
        }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }


}
