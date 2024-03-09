using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        MyBookshelfContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(MyBookshelfContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var category = _categoryService.GetListAll();
            return View(category);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _categoryService.Insert(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var values = _categoryService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            category.Status = true;
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        public IActionResult ActiveCategory(int id)
        {
            _categoryService.CategoryStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult PassiveCategory(int id)
        {
            _categoryService.CategoryStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
