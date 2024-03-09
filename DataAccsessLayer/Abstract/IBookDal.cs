using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Abstract
{
    public interface IBookDal : IGenericDal<Book>
    {

        void BookStatusToTrue(int id);
        void BookStatusToFalse(int id);
        List<Book> GetListActiveBooks();

    }
}
