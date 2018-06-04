using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class Classification
    {
        public Classification()
        {
            Type = new HashSet<Type>();
        }

        public int ClassificationId { get; set; }
        public string Name { get; set; }

        public ICollection<Type> Type { get; set; }
    }
}
