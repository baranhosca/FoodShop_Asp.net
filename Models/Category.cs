using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FoodShop.Models
{
	public class Category
	{
		public int CategoryID { get; set; }

		[Required(ErrorMessage = "Category name cannot be empty!")]
		[StringLength(20, ErrorMessage = "Please enter between 4-20 characters!", MinimumLength = 4)]
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public bool Status { get; set; } = true;
		public List<Food> Foods { get; set; }
	}
}
