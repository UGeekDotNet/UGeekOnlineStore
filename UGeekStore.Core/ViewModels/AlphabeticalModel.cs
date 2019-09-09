using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.ViewModels
{
    public class AlphabeticalModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string   Name { get; set; }
        public string   CategoryName { get; set; }
        public decimal   UnitPrice { get; set; }
    }
}
