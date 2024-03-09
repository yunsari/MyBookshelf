using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _LoginHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
