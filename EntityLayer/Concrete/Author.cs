using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorNameSurname { get; set; }
        public string AuthorCountry { get; set; }
        public string AuthorBirthday { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImage { get; set; }
        public bool Status { get; set; }

        //public virtual List<AuthorsWord> AuthorsWords { get; set;}
        //public virtual List<Book> Books { get; set;}

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<AuthorsWord> AuthorsWords { get; set; }
    }
}
