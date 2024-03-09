using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public readonly MyBookshelfContext _context;

        public AuthorController(IAuthorService authorService, MyBookshelfContext context)
        {
            _authorService = authorService;
            this._context = context;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var author = _authorService.GetListAll();
            return View(author);
        }

        [HttpGet]
        public IActionResult AddAuthor() 
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _authorService.Insert(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var values = _authorService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAuthor(Author author)
        {
            author.Status = true;
            _authorService.Update(author);
            return RedirectToAction("Index");
        }

        public IActionResult ActiveAuthor(int id)
        {
            _authorService.AuthorStatusToTrue(id);
            return RedirectToAction("Index");
        } 

        public IActionResult PassiveAuthor(int id)
        {
            _authorService.AuthorStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
