using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class OrderLine
    {
        public int LineId { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int ObjectId { get; set; }
        public int OrderId { get; set; }

        public OrderObject Object { get; set; }
        public Order Order { get; set; }
    }
}
