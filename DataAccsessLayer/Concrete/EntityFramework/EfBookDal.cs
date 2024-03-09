using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repository;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.EntityFramework
{
    public class EfBookDal : GenericRepository<Book>, IBookDal
    {
        public void BookStatusToFalse(int id)
        {
            using var context = new MyBookshelfContext();
            Book book = context.Books.Find(id);
            book.Status = false;
            context.SaveChanges();
        }

        public void BookStatusToTrue(int id)
        {
            using var context = new MyBookshelfContext();
            Book book = context.Books.Find(id);
            book.Status = true;
            context.SaveChanges();
        }

        public List<Book> GetListActiveBooks()
        {
            return GetListAll().Where(x => x.Status == true).ToList();
        }
    }
}
