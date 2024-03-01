
using Library_Web.Models;
using Library_Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Web.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    public class HireController : Controller
    {
        private readonly IHireRepository _hireRepository;
        private readonly IBookRepository _bookRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

       
        public HireController(IHireRepository hireRepository, IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment) 
        {
            _hireRepository = hireRepository;
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index() 
        {
            	
            List<Hire> objHireList = _hireRepository.GetAll(includeProps: "Book").ToList(); 
            return View(objHireList); 
        }
        public IActionResult AddUpdate(int? id) 
        {
            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem 
            {
                Text = k.BookName, 
                Value = k.Id.ToString() 
            });
            ViewBag.BookList = BookList;
            if (id == null || id == 0) 
            {
           
                return View();
            }
            else
            {
                
                Hire hireDb = _hireRepository.Get(u => u.Id == id);
                if (hireDb == null)
                {
                    return NotFound();
                }


                return View(hireDb);
            }
        }

        [HttpPost]
        public IActionResult AddUpdate(Hire hire) 
        {

            

            if (ModelState.IsValid) 
            {                      
                if (hire.Id == 0)
                {
                    _hireRepository.Add(hire);
                    TempData["successful"] = "New Book Hired Successfuly";
                }
                else
                {
                    _hireRepository.Update(hire);
                    TempData["successful"] = "New Book Hired Updated Successfuly";
                }

                _hireRepository.Save(); 

                return RedirectToAction("Index", "Hire"); 
            }

            return View();

        }


       
        public IActionResult Delete(int? id)
        {

            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem 
            {
                Text = k.BookName, 
                Value = k.Id.ToString() 
            });
            ViewBag.BookList = BookList; 
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Hire? hireDb = _hireRepository.Get(u => u.Id == id);
            if (hireDb == null)
            {
                return NotFound();



            }
            return View(hireDb);



        }

        [HttpPost, ActionName("Sil")]
        public IActionResult DeletePost(Hire hire)
        {

            if (hire == null)
            {
                _hireRepository.Remove(hire); 
                _hireRepository.Save(); 
                TempData["successful"] = "New Hired Book Deleted Successfuly";
                return RedirectToAction("Index", "Hire"); 
            }
            return View();


        }

    }
}
