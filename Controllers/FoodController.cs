using FoodShop.Models;
using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace FoodShop.Controllers
{
	public class FoodController : Controller
	{
		FoodRepository foodRepository = new FoodRepository();

		Context c = new Context();
		public IActionResult Index(int page = 1)
		{
			return View(foodRepository.TList("Category").ToPagedList(page,3));
		}
		[HttpGet]
		public IActionResult FoodAdd()
		{
			List<SelectListItem> values=(from x in c.Categories.ToList()
										 select new SelectListItem
										 {
											 Text=x.CategoryName,
											 Value=x.CategoryID.ToString()
										 }).ToList();
			ViewBag.v1 = values;
			return View();
		}
		[HttpPost]
		public IActionResult FoodAdd(AddProduct p)
		{
			Food f = new Food();
			if(p.ImageURL != null)
			{
				var extension = Path.GetExtension(p.ImageURL.FileName);
				var newImageName = Guid.NewGuid() +extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				p.ImageURL.CopyTo(stream);
				f.ImageURL = newImageName;
			} 
			f.FoodName = p.Name;
			f.Price = p.Price;
			f.Stock = p.Stock;
			f.CategoryID = p.CategoryID;
			f.ShortDescription = p.ShortDescription;
			foodRepository.TAdd(f);
			return RedirectToAction("Index");
		}
		public IActionResult FoodDelete(int id)
		{
			foodRepository.TDelete(new Food { FoodID = id });
			return RedirectToAction("Index");
		}
		public IActionResult FoodGet(int id)
		{
			var x = foodRepository.TGet(id);
			List<SelectListItem> values = (from y in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text = y.CategoryName,
											   Value = y.CategoryID.ToString()
										   }).ToList();
			ViewBag.v1 = values;
			Food f = new Food()
			{
				CategoryID = x.CategoryID,
				FoodID = x.FoodID,
				FoodName = x.FoodName,
				Price = x.Price,
				Stock = x.Stock,
				ImageURL = x.ImageURL,
				ShortDescription = x.ShortDescription,
			};
			return View(f);
		}
		public IActionResult FoodUpdate(Food p)
		{
			var x = foodRepository.TGet(p.FoodID);
			x.FoodName = p.FoodName;
			x.ShortDescription = p.ShortDescription;
			x.Price = p.Price;
			x.ImageURL = p.ImageURL;
			x.Stock = p.Stock;
			x.CategoryID = p.CategoryID;
			foodRepository.TUpdate(x);
			return RedirectToAction("Index");
		}
	}
}
