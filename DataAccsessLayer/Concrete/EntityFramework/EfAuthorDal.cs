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
    public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public void AuthorStatusToFalse(int id)
        {
            using var context = new MyBookshelfContext();
            Author auth = context.Authors.Find(id);
            auth.Status = false;
            context.SaveChanges();
        }

        public void AuthorStatusToTrue(int id)
        {
            using var context = new MyBookshelfContext();
            Author auth = context.Authors.Find(id);
            auth.Status = true;
            context.SaveChanges();
        }
    }
}
