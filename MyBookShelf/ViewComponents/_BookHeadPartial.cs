using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _BookHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {  return View(); }
    }
}
