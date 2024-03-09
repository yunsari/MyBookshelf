using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _AuthorHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
