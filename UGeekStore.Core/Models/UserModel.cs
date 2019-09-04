using System;
using System.Collections.Generic;
using System.Text;

namespace UGeekStore.Core.Models
{
    public class UserModel 
    {
        public int ID { get; set; }
        public int AccessID { get; set; }
        public string UserName { get; set; }
        private string _password;
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value.Length >= 8 && value.Length <= 25)
                {
                    this._password = value;
                }
                else
                {
                    throw new Exception("Password lengt must be form 8 symbol to 25");
                }
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
