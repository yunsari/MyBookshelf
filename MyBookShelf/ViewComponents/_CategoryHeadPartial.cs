using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _CategoryHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
