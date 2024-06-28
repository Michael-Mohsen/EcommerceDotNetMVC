using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecommerce1.Models
{
    public partial class CartItem
    {
		[Key]
		public int CartItemId { get; set; }
		[ForeignKey("Order")]
		public int? CartId { get; set; }
		[ForeignKey("Product")]
		public int? ProductId { get; set; }
		public int? UserId { get; set; }
		public int? Quantity { get; set; }
		public decimal? Price { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Product? Product { get; set; }
		public virtual Userr? Userr { get; set; }
        public string? Name { get; internal set; }
        public string? Image { get; internal set; }
    }
}
