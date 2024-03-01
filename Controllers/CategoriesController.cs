using Library_Web.Models;
using Library_Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Web.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CategoriesController : Controller
	{
		private readonly ICategoriesRepository _categoriesRepository;
		public CategoriesController(ICategoriesRepository Context)
		{
			_categoriesRepository = Context;
		}
		public IActionResult Index()
		{
			List<Categories> objCategoriesList = _categoriesRepository.GetAll().ToList(); 
			return View(objCategoriesList);
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Categories categories)
		{



			if (ModelState.IsValid) 
			{
				_categoriesRepository.Add(categories);
				_categoriesRepository.Save(); 
				TempData["successful"] = "New Book Categories Added Successfuly";
				return RedirectToAction("Index", "Categories"); 
			}
			return View();
		}

		public IActionResult Update(int id)
		{


			Categories categoriesDb = _categoriesRepository.Get(u => u.Id == id); 


			return View(categoriesDb);
		}

		[HttpPost]
		public IActionResult Update(Categories categories)
		{



			if (ModelState.IsValid) 
			{
				_categoriesRepository.Update(categories);
				_categoriesRepository.Save();
				TempData["successful"] = "New Book Categories Updated Successfuly!";
				return RedirectToAction("Index", "Categories"); 
			}
			return View();
		}
		
		public IActionResult Delete(int? id)
		{
			Categories categorisDb = _categoriesRepository.Get(u => u.Id == id);
			return View(categorisDb);
		}

		[HttpPost]
		public IActionResult DeletePost(Categories categories)
		{

			if (categories != null)
			{
				_categoriesRepository.Remove(categories); 
				_categoriesRepository.Save();
				TempData["successful"] = "New Book Categories Deleted Successfuly";
				return RedirectToAction("Index", "Categories"); 
			}
			return View();


		}
	}

}
