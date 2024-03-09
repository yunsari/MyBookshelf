using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBookshelf.ViewComponents
{
    public class _AuthorWordsPartial : ViewComponent
    {
        public readonly MyBookshelfContext _myBookshelfContext;

        public _AuthorWordsPartial(MyBookshelfContext myBookshelfContext)
        {
            _myBookshelfContext = myBookshelfContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authorsWords = await _myBookshelfContext.AuthorsWords.ToListAsync();

            var authors = await _myBookshelfContext.Authors.ToListAsync();

            return View((authorsWords, authors));
        }
    }
}
