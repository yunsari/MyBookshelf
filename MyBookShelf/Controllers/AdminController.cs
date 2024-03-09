using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var admins = _adminService.GetListAll();
            return View(admins);
        }
    }
}
