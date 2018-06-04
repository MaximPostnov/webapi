using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class Type
    {
        public Type()
        {
            OrderObject = new HashSet<OrderObject>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }
        public ICollection<OrderObject> OrderObject { get; set; }
    }
}
