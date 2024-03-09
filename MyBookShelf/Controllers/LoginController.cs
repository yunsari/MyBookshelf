using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MyBookshelf.Controllers
{
    public class LoginController : Controller
    {
        MyBookshelfContext _myBookshelfContext;
        private readonly IContactService _contactService;

        public LoginController(MyBookshelfContext myBookshelfContext, IContactService contactService)
        {
            _myBookshelfContext = myBookshelfContext;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {

            var values = _myBookshelfContext.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (values != null)
            {
                var userClaims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, values.Username)
                };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "local"));
                await HttpContext.SignInAsync("AuthSchemeBooks", principal);

                HttpContext.Session.SetString("Username", values.Username.ToString());

                string userName = HttpContext.Session.GetString("Username");

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }


            //var values = _myBookshelfContext.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            //if (values != null)
            //{
            //    FormsAuthentication.SetAuthCookie(values.Username, false);
            //    Session["Username"] = values.Username.ToString();
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync("AuthSchemeBooks");
            return RedirectToAction("Index", "Login");

            //FormsAuthentication.SignOut();
            //Session.Abandon();
            //return RedirectToAction("Index", "Login");
        }
    }
}
