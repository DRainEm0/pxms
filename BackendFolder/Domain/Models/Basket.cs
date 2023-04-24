using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Basket
    {
        public int ItemId { get; set; }
        public int DealId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = null!;

        public virtual Item Item { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}
