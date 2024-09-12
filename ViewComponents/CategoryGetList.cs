using FoodShop.Models;
using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.ViewComponents
{
	public class CategoryGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepository categoryRepository = new CategoryRepository();
			var categoryList = categoryRepository.TList();
			return View(categoryList);
		}
	}
}
