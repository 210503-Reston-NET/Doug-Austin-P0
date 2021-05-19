using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string UserAddress { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
