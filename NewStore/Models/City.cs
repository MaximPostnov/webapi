using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class City
    {
        public City()
        {
            Manufacturer = new HashSet<Manufacturer>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public County Country { get; set; }
        public ICollection<Manufacturer> Manufacturer { get; set; }
    }
}
