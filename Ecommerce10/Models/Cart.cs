using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce1.Models
{
    public partial class Cart
    {
		[Key]
		public int CartId { get; set; }
		[ForeignKey("Userr")]
		public int? UserId { get; set; }
		public int? Quanatity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public virtual Userr? Userr { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
