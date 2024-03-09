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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public void CategoryStatusToFalse(int id)
        {
            using var context = new MyBookshelfContext();
            Category cate = context.Categories.Find(id);
            cate.Status = false;
            context.SaveChanges();
        }

        public void CategoryStatusToTrue(int id)
        {
            using var context = new MyBookshelfContext();
            Category cate = context.Categories.Find(id);
            cate.Status = true;
            context.SaveChanges();
        }
    }
}
