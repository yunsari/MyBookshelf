using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Contexts
{
    public class MyBookshelfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=PC;database=MyBookshelfDB;Encrypt=False;integrated security=true");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorsWord> AuthorsWords { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
