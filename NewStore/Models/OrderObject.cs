using System;
using System.Collections.Generic;

namespace NewStore.Models
{
    public partial class OrderObject
    {
        public OrderObject()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Availability { get; set; }
        public int ManufacturerId { get; set; }
        public int TypeId { get; set; }
        public string Image { get; set; }//byte[] Image { get; set; }  //Переделать в стринг

        public Manufacturer Manufacturer { get; set; }
        public Type Type { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
    }
}
