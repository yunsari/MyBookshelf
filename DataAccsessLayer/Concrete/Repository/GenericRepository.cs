using DataAccsessLayer.Abstract;
using DataAccsessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using var context = new MyBookshelfContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var context = new MyBookshelfContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var context = new MyBookshelfContext();
            return context.Set<T>().ToList();   
        }

        public void Insert(T t)
        {
            using var context = new MyBookshelfContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new MyBookshelfContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
