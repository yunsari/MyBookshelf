using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _HomeAboutMeSectionPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
