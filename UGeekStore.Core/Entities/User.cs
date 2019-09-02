using System;
using System.Collections.Generic;
using System.Text;
using UGeekStore.Core.Infrastructre.EntityAbstraction;

namespace UGeekStore.DAL.Entities
{
    public class User : EntitiyBaseWithId
    { 
        public int AccessId { get; set; }
        public string Name { get; set; }
        public string Password
        {
            get { return Password; }
            set
            {
                if (value.Length >= 8)
                {
                    Password = value;
                }
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ShipAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShipPostalCode { get; set; }
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Message> MessagesReciver { get; set; }
    } 
}
