using FoodShop.Models;
using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.ViewComponents
{
	public class FoodGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodlist = foodRepository.TList();
			return View(foodlist);
		}
	}
}
