using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecommerce1.Models
{
    public partial class Userr
    {
		
		[Key]
		public int UserId { get; set; }
		[ForeignKey("Cart")]
		public int CartId { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Passward { get; set; }

		public virtual Cart? Cart { get; set; }

	}
}
