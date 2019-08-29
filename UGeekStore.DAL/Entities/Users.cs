using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class Users  : EntitiyBaseWithId
    {
        public int AccessID { get; set; }
        public string UserName { get; set; }
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
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrDate { get; set; }
        public string ShipAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShipPostalCode { get; set; }

        public Rolies Rolies { get; set; }

        public ICollection<Messages>  Messages { get; set; }

        public ICollection<Orders> Orders { get; set; }



    }
}
