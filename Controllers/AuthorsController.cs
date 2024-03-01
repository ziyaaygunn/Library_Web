using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library_Web.Controllers
{
	public class AuthorsController : Controller
	{
		public IActionResult Index() 
		{
			return View();
		}


		public IActionResult Details()
		{
			return View();	
		}


	}

}
