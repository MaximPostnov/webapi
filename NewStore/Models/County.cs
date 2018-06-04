using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class County
    {
        public County()
        {
            City = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
