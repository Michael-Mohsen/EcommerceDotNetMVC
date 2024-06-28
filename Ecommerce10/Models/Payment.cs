using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce1.Models
{
    public partial class Payment
    {
		[Key]
		public int PaymentId { get; set; }
		public DateTime? Date { get; set; }
		public int? Amount { get; set; }
		[ForeignKey("Order")]
		public int? OrderId { get; set; }

		public virtual Order? Order { get; set; }
	}
}
