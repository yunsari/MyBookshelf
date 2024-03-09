using Microsoft.AspNetCore.Mvc;

namespace MyBookshelf.ViewComponents
{
    public class _LoginScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
