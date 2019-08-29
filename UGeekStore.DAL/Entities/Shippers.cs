using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class Shippers : EntitiyBaseWithId
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string  Country { get; set; }
        public string  City { get; set; }
        public string  Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }

        public ICollection<Orders> Orders { get; set; }

    }
}
