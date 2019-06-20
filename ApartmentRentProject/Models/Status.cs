using System;
using System.Collections.Generic;

namespace ApartmentRentProject.Models
{
    public partial class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
