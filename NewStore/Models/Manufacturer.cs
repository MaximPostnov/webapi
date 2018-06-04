using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            OrderObject = new HashSet<OrderObject>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public ICollection<OrderObject> OrderObject { get; set; }
    }
}
