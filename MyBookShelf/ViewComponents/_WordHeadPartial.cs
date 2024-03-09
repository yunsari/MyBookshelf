using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _WordHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
