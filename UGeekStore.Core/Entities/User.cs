using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.Core.Entities
{
    public class User : EntityBaseWithId
    {
        public int AccessID { get; set; }
        public string Name { get; set; }
        private string _password;
        public string Password
        {
            get { return this._password; }
            set
            {
                if (value.Length >= 8)
                    this._password = value;
                else
                    throw new Exception("Your password must be at least 8 characters !!!");
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

       public Role Role { get; set; }

       public ICollection<Message> Messages { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
