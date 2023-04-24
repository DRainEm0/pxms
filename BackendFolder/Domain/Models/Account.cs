using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Account
    {
        public Account()
        {
            Baskets = new HashSet<Basket>();
            Deliveries = new HashSet<Delivery>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Photo { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
