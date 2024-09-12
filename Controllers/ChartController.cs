using FoodShop.Models;
using FoodShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
	public class ChartController : Controller
	{
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            Context context = new Context();
            return Json(context.Foods.ToList());
        }
        public List<Class1> FoodList()
        {
            List<Class1> cs2 = new List<Class1>();
            FoodRepository f = new FoodRepository();

            cs2 = f.TList().Select(x => new Class1()
            {
                foodname = x.FoodName,
                stock = x.Stock
            }).ToList();
            return cs2;
        }

        public IActionResult Statistics()
        {
            Context context = new Context();

            var value1 = context.Foods.Count();
            ViewBag.v1 = value1;

			var value2 = context.Categories.Count();
			ViewBag.v2 = value2;

            var foid = context.Categories.Where(x => x.CategoryName == "Fruits").Select(y => 
                y.CategoryID).FirstOrDefault();
            ViewBag.d = foid;
            var value3 = context.Foods.Where(x=> x.CategoryID == foid).Count();
            ViewBag.v3 = value3;

            var value4 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(z => z.CategoryName == 
            "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.v4 = value4;

            var value5 = context.Foods.Sum(x=>x.Stock);
            ViewBag.v5 = value5;

            var value6 = context.Foods.Where(x=> x.CategoryID==context.Categories.Where(y=> y.CategoryName ==
            "Legumes").Select(z=>z.CategoryID).FirstOrDefault()).Count();
            ViewBag.v6 = value6;

            var value7 = context.Foods.OrderByDescending(x => x.Stock).Select(y =>
            y.FoodName).FirstOrDefault();
            ViewBag.v7 = value7;

            var value8 = context.Foods.OrderBy(x => x.Stock).Select(y =>
            y.FoodName).FirstOrDefault();
            ViewBag.v8 = value8;

            var value9 = context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.v9 = value9;

            var value10 = context.Categories.Where(x => x.CategoryName == "Fruits").Select(y =>
            y.CategoryID).FirstOrDefault();
            var value10p = context.Foods.Where(y => y.CategoryID == value10).Sum(x => x.Stock);
            ViewBag.v10 = value10p;

            var value11 = context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y =>
            y.CategoryID).FirstOrDefault();
            var value11p = context.Foods.Where(y => y.CategoryID == value11).Sum(x => x.Stock);
            ViewBag.v11 = value11p;

            var value12 = context.Foods.OrderByDescending(x => x.Price).Select(y =>
            y.FoodName).FirstOrDefault();
            ViewBag.v12 = value12;

            return View();
        }
    }
}
