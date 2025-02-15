﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce1.Models
{
    public partial class Category
    {
		public Category()
		{
			Products = new HashSet<Product>();
		}

		[Key]
		public int CategoryId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		public virtual ICollection<Product>? Products { get; set; }
	}
}
