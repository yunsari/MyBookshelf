using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _ContactHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
