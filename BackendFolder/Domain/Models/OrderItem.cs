using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string DeliveryStatus { get; set; } = null!;
        public DateTime DateOfCreate { get; set; }
        public DateTime Deadline { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}
