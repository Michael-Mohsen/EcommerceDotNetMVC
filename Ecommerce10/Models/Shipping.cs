using System;
using System.Collections.Generic;

namespace Ecommerce1.Models
{
    public partial class Shipping
    {
        public int ShippingId { get; set; }
        public DateTime? Date { get; set; }
        public string? Address { get; set; }
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
    }
}
