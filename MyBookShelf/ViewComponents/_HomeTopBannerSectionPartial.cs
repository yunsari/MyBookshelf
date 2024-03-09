using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _HomeTopBannerSectionPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
