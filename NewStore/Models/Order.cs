using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public bool SoldOut { get; set; }

        public UserReg User { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
    }
}
