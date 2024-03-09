using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AuthorsWord
    {
        public int AuthorsWordID { get; set; }
        public string AuthorWord { get; set; }
        public int AuthorID { get; set; }
        public bool Status { get; set; }

        public virtual Author Author { get; set; }
    }
}
