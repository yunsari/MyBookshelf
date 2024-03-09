using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorsWordService : IGenericService<AuthorsWord>
    {
        void WordStatusToTrue(int id);
        void WordStatusToFalse(int id);
    }
}
