using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryStatusToFalse(int id)
        {
            _categoryDal.CategoryStatusToFalse(id);
        }

        public void CategoryStatusToTrue(int id)
        {
            _categoryDal.CategoryStatusToTrue(id);
        }

        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> GetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void Insert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
