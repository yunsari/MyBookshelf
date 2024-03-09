using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        MyBookshelfContext _context;

        public ContactController(IContactService contactService, MyBookshelfContext context)
        {
            _contactService = contactService;
            _context = context;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var values = _contactService.GetListAll();
            return View(values);
        }
    }
}
