using System;
using System.Collections.Generic;

namespace ApartmentRentProject.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool? Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
