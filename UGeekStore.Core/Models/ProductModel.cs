using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public int Count { get; set; }
    }
}
