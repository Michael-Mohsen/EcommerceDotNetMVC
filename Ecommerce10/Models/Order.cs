using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce1.Models
{
    public partial class Order
    {
		public Order()
		{
			Payments = new HashSet<Payment>();
			Shippings = new HashSet<Shipping>();
		}



		[Key]
		public int OrderId { get; set; }
		public DateTime? Date { get; set; }
		public decimal? TotalPrice { get; set; }
		[ForeignKey("Userr")]
		public int? UserId { get; set; }
		[ForeignKey("Cart")]
		public int? CartId { get; set; }

		public virtual Userr? Userr { get; set; }
		public virtual Cart? Cart { get; set; }
		public virtual ICollection<Payment>? Payments { get; set; }
		public virtual ICollection<Shipping>? Shippings { get; set; }
	}
}
