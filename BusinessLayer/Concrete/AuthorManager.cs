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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void AuthorStatusToFalse(int id)
        {
            _authorDal.AuthorStatusToFalse(id);
        }

        public void AuthorStatusToTrue(int id)
        {
            _authorDal.AuthorStatusToTrue(id);
        }

        public void Delete(Author t)
        {
            _authorDal.Delete(t);
        }

        public Author GetById(int id)
        {
            return _authorDal.GetByID(id);
        }

        public List<Author> GetListAll()
        {
            return _authorDal.GetListAll();
        }

        public void Insert(Author t)
        {
            _authorDal.Insert(t);
        }

        public void Update(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
