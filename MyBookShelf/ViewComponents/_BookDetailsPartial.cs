using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBookshelf.ViewComponents
{
    public class _BookDetailsPartial : ViewComponent
    {
        public readonly IBookService _bookService;
        public readonly MyBookshelfContext _myBookshelfContext;

        public _BookDetailsPartial(IBookService bookService, MyBookshelfContext myBookshelfContext)
        {
            _bookService = bookService;
            _myBookshelfContext = myBookshelfContext;
        }

        public IViewComponentResult Invoke(int id)
        {
            var findid = _bookService.GetById(id);
            var book = _myBookshelfContext.Books.Include(x => x.Author).Include(x => x.Category).FirstOrDefault(x => x.BookID == id);

            return View(book);
        }
    }
}
