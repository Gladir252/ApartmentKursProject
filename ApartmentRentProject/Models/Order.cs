using System;
using System.Collections.Generic;

namespace ApartmentRentProject.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }

        public virtual Product IdNavigation { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
