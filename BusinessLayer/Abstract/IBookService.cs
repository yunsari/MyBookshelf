using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        void BookStatusToTrue(int id);
        void BookStatusToFalse(int id);
        List<Book> GetListActiveBooks();

    }
}
