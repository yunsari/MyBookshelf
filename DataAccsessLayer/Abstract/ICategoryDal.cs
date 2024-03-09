using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        void CategoryStatusToTrue(int id);
        void CategoryStatusToFalse(int id);
    }
}
