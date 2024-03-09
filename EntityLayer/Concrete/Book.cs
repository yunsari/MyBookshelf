using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int AuthorID { get; set; }
        public int NumberOfBookPage { get; set; }
        public decimal BookPrice { get; set; }
        public int CategoryID { get; set; }
        public string BookImage { get; set; }
        public string? BookDescription { get; set; }
        public bool Status { get; set; }
        public bool Favorite { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
