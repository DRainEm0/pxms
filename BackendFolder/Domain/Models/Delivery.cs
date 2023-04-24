using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string CityIndex { get; set; } = null!;
        public string Home { get; set; } = null!;
        public string? Apartment { get; set; }

        public virtual Account User { get; set; } = null!;
    }
}
