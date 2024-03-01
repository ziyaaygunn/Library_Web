using Library_Web.Models;
using Library_Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Web.Controllers
{

    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository bookRepository, ICategoriesRepository categoriesRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _categoriesRepository = categoriesRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Student")]
        public IActionResult Index()
        {

            List<Book> objBookList = _bookRepository.GetAll(includeProps: "Categories").ToList();
            return View(objBookList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult AddUpdate(int? id)
        {
            IEnumerable<SelectListItem> CategoriesList = _categoriesRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.Name,
                Value = k.Id.ToString()
            });
            ViewBag.CategoriesList = CategoriesList;
            if (id == null || id == 0)
            {

                return View();
            }
            else
            {

                Book bookDb = _bookRepository.Get(u => u.Id == id);
                if (bookDb == null)
                {
                    return NotFound();
                }


                return View(bookDb);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult AddUpdate(Book book, IFormFile? file)
        {



            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string bookPath = Path.Combine(wwwRootPath, @"images");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(bookPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                book.ImageUrl = @"\images\" + file.FileName;
                if (book.Id == 0)
                {
                    _bookRepository.Add(book);
                    TempData["successful"] = "New Book Added Successfuly";
                }
                else
                {
                    _bookRepository.Update(book);
                    TempData["successful"] = "New Book Updated Successfuly";
                }

                _bookRepository.Save();

                return RedirectToAction("Index", "Book");

            }
            return View();

        }

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            Book bookDb = _bookRepository.Get(u => u.Id == id);
            return View(bookDb);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult DeletePost(Book book)
        {

            if (book != null)
            {
                _bookRepository.Remove(book);
                _bookRepository.Save();
                TempData["successful"] = "New Book Deleted Successfuly";
                return RedirectToAction("Index", "Book");
            }
            return View();


        }


    }
}
