using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Models
{
    public class ShipperModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }
}
