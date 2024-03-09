using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookshelf.Models;
using System.Diagnostics;
using X.PagedList;
using X.PagedList.Mvc;
using X.PagedList.Mvc.Core;

namespace MyBookshelf.Controllers
{
    public class HomeController : Controller
    {

        MyBookshelfContext _myBookshelfContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IContactService _contactService;
        public HomeController(MyBookshelfContext myBookshelfContext, ILogger<HomeController> logger, IBookService bookService, IContactService contactService)
        {
            _myBookshelfContext = myBookshelfContext;
            _logger = logger;
            _bookService = bookService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            int countOfBooks = _myBookshelfContext.Books.Where(x => x.Status == true).Count();
            int countOfAuthors = _myBookshelfContext.Authors.Where(x => x.Status == true).Count();
            decimal totalPrice = _myBookshelfContext.Books.Where(x => x.Status == true).Sum(x => x.BookPrice);
            int countOfCategories = _myBookshelfContext.Categories.Where(x => x.Status == true).Count();

            ViewBag.CountOfBooks = countOfBooks;
            ViewBag.CountOfAuthors = countOfAuthors;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.CountOfCategories = countOfCategories;

            return View();
        }

        public IActionResult Books(int? page)
        {
            var values = _bookService.GetListActiveBooks();
            var pageNumber = page ?? 1;
            var pageSize = 6;
            var pagedBooks = values.ToPagedList(pageNumber, pageSize);
            return View(pagedBooks);
        }

        public IActionResult BookDetails(int id)
        {
            var findid = _bookService.GetById(id);
            var book = _myBookshelfContext.Books.Include(x => x.Author).Include(x => x.Category).FirstOrDefault(x => x.BookID == id);
            return View(book);
        }

        public IActionResult About()
        {
            int countOfBooks = _myBookshelfContext.Books.Where(x => x.Status == true).Count();
            int countOfAuthors = _myBookshelfContext.Authors.Where(x => x.Status == true).Count();
            decimal totalPrice = _myBookshelfContext.Books.Where(x => x.Status == true).Sum(x => x.BookPrice);
            int countOfCategories = _myBookshelfContext.Categories.Where(x => x.Status == true).Count();

            ViewBag.CountOfBooks = countOfBooks;
            ViewBag.CountOfAuthors = countOfAuthors;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.CountOfCategories = countOfCategories;

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Insert(contact);
            return View();
        }

        public IActionResult IStiklalMarsi()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
