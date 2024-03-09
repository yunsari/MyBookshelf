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
    public class EfAuthorsWordDal : GenericRepository<AuthorsWord>, IAuthorsWordDal
    {
        public void WordStatusToFalse(int id)
        {
            using var context = new MyBookshelfContext();
            AuthorsWord word = context.AuthorsWords.Find(id);
            word.Status = false;
            context.SaveChanges();
        }

        public void WordStatusToTrue(int id)
        {
            using var context = new MyBookshelfContext();
            AuthorsWord word = context.AuthorsWords.Find(id);
            word.Status = true;
            context.SaveChanges();
        }
    }
}
