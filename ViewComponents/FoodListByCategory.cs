using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.ViewComponents
{
	public class FoodListByCategory : ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodlist = foodRepository.List(x=>x.CategoryID == id);
			return View(foodlist);
		}
	}
}
