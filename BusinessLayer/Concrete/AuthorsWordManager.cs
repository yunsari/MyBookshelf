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
    public class AuthorsWordManager : IAuthorsWordService
    {
        IAuthorsWordDal _authorsWordDal;

        public AuthorsWordManager(IAuthorsWordDal authorsWordDal)
        {
            _authorsWordDal = authorsWordDal;
        }

        public void Delete(AuthorsWord t)
        {
            _authorsWordDal.Delete(t);
        }

        public AuthorsWord GetById(int id)
        {
            return _authorsWordDal.GetByID(id);
        }

        public List<AuthorsWord> GetListAll()
        {
            return _authorsWordDal.GetListAll();
        }

        public void Insert(AuthorsWord t)
        {
            _authorsWordDal.Insert(t);
        }

        public void Update(AuthorsWord t)
        {
            _authorsWordDal.Update(t);
        }

        public void WordStatusToFalse(int id)
        {
            _authorsWordDal.WordStatusToFalse(id);
        }

        public void WordStatusToTrue(int id)
        {
            _authorsWordDal.WordStatusToTrue(id);
        }
    }
}
