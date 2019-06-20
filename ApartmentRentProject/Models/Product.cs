using System;
using System.Collections.Generic;

namespace ApartmentRentProject.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddingDate { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }
    }
}
