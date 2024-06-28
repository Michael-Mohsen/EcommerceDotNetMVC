using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ecommerce1.Models
{
    public partial class Product
    {
		//public Product()
		//{
		//	Cart = new HashSet<Cart>();
			
		//}

		[Key]
		public int ProductId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		[DefaultValue("~/Ecommroot/images/internet security.jpg")]
		public string? Image { get; set; }
		public decimal? Price { get; set; }
		public int? Quantaty { get; set; }
		[ForeignKey("Category")]
		public int? CategoryId { get; set; }

		public virtual Category? Category { get; set; }
		
		
	}
}
