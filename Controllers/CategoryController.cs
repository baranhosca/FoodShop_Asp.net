using FoodShop.Repositories;
using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FoodShop.Controllers
{
	public class CategoryController : Controller
	{
		CategoryRepository categoryRepository = new CategoryRepository();
		public IActionResult Index(string p)
		{
			if(!string.IsNullOrEmpty(p))
			{
				return View(categoryRepository.List(x => x.CategoryName == p));
			}
			return View(categoryRepository.TList());
		}
		[HttpGet]
		public IActionResult CategoryAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CategoryAdd(Category p)
		{
			categoryRepository.TAdd(p);
			return RedirectToAction("Index");
		}
		public IActionResult CategoryGet(int id)
		{
			var x = categoryRepository.TGet(id);
			Category ct = new Category()
			{
				CategoryName = x.CategoryName,
				CategoryDescription = x.CategoryDescription,
				CategoryID = x.CategoryID,
			};
			return View(ct);
		}
		public IActionResult CategoryDelete(int id)
		{
			categoryRepository.TDelete(new Category { CategoryID = id });
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult CategoryUpdate(Category p)
		{
			categoryRepository.TUpdate(p);
			return RedirectToAction("Index");
		}
	}
}
