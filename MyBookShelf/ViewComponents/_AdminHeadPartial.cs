using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _AdminHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
