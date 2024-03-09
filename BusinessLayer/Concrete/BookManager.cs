using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void BookStatusToFalse(int id)
        {
            _bookDal.BookStatusToFalse(id);
        }

        public void BookStatusToTrue(int id)
        {
            _bookDal.BookStatusToTrue(id);
        }

        public void Delete(Book t)
        {
            _bookDal.Delete(t);
        }

        public Book GetById(int id)
        {
            return _bookDal.GetByID(id);
        }

        public List<Book> GetListActiveBooks()
        {
            return _bookDal.GetListActiveBooks();
        }

        public List<Book> GetListAll()
        {
            return _bookDal.GetListAll();
        }

        public void Insert(Book t)
        {
            _bookDal.Insert(t);
        }

        public void Update(Book t)
        {
            _bookDal.Update(t);
        }
    }
}
