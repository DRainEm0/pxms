using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Item
    {
        public Item()
        {
            Baskets = new HashSet<Basket>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Price { get; set; }
        public string? Photo { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
