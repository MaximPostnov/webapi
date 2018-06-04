using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace NewStore.Models
{
        public class UserReg : IdentityUser
        {
        public ICollection<Order> Order { get; set; }
        }

}

//using System;
//using System.Collections.Generic;

//namespace NewStore.Models
//{
//    public partial class User
//    {
//        public User()
//        {
//            Order = new HashSet<Order>();
//        }

//        public int UserId { get; set; }
//        public string Name { get; set; }
//        public string Password { get; set; }
//        public bool StatusAdmin { get; set; }
//        public byte[] Image { get; set; }

//        public ICollection<Order> Order { get; set; }
//    }
//}
