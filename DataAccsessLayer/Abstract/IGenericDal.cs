using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetByID(int id);
        List<T> GetListAll();
    }
}
