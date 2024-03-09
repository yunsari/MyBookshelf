using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class AuthorswordController : Controller
    {
        IAuthorsWordService _authorsWordService;
        MyBookshelfContext _context;

        public AuthorswordController(IAuthorsWordService authorsWordService, MyBookshelfContext cntx)
        {
            _authorsWordService = authorsWordService;
            _context = cntx;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var word = _context.AuthorsWords.Include(x => x.Author).ToList();
            return View(word);
        }

        [HttpGet]
        public ActionResult AddWord()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            List<SelectListItem> deger = (from x in _context.Authors.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AuthorNameSurname,
                                              Value = x.AuthorID.ToString()
                                          }).ToList();

            ViewBag.dgr = deger;
            return View();
        }

        [HttpPost]
        public ActionResult AddWord(AuthorsWord authorsWord)
        {
            _authorsWordService.Insert(authorsWord);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ActiveWord(int id)
        {
            _authorsWordService.WordStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult PassiveWord(int id)
        {
            _authorsWordService.WordStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
