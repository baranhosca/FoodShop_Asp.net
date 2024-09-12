using Microsoft.AspNetCore.Http;

namespace FoodShop.Models
{
	public class AddProduct
	{
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public double Price { get; set; }
		public IFormFile ImageURL { get; set; }
		public int Stock { get; set; }
		public int CategoryID { get; set; }
	}
}
