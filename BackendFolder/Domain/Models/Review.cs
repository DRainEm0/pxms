using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string? Opinion { get; set; }
        public string? Photo { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual Account User { get; set; } = null!;
    }
}
