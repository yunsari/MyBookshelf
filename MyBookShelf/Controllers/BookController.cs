using Azure.Core;
using BusinessLayer.Abstract;
using DataAccsessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;
using X.PagedList.Mvc;
using X.PagedList.Mvc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;

namespace MyBookshelf.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        MyBookshelfContext _myBookshelfContext;

        public BookController(IBookService bookService, MyBookshelfContext myBookshelfContext)
        {
            _bookService = bookService;
            _myBookshelfContext = myBookshelfContext;
        }

        public ActionResult Index()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            var book = _myBookshelfContext.Books.Include(x => x.Author).Include(x => x.Category).ToList();
            return View(book);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;

            List<SelectListItem> deger1 = (from x in _myBookshelfContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in _myBookshelfContext.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorNameSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(AddBook addbook)
        {
            Book book = new Book();
            if (addbook.BookImage != null)
            {
                var extension = Path.GetExtension(addbook.BookImage.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                addbook.BookImage.CopyTo(stream);
                book.BookImage = imagename;
            }
            book.BookName = addbook.BookName;
            book.AuthorID = addbook.AuthorID;
            book.NumberOfBookPage = addbook.NumberOfBookPage;
            book.CategoryID = addbook.CategoryID;
            book.Status = addbook.Status;
            book.BookPrice = addbook.BookPrice;
            book.BookDescription = addbook.BookDescription;

            _bookService.Insert(book);
            _myBookshelfContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BookDetails(int id)
        {
            var userName = HttpContext.Session.GetString("Username");
            ViewBag.username = userName;


            List<SelectListItem> deger1 = (from x in _myBookshelfContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in _myBookshelfContext.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorNameSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;

            var values = _bookService.GetById(id);
            return View(values);
        }

        public IActionResult EditBook(AddBook addbook)
        {
            Book book = _bookService.GetById(addbook.BookID);
            if (addbook.BookImage != null)
            {
                var extension = Path.GetExtension(addbook.BookImage.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                addbook.BookImage.CopyTo(stream);
                book.BookImage = imagename;
            }

            book.BookName = addbook.BookName;
            book.AuthorID = addbook.AuthorID;
            book.NumberOfBookPage = addbook.NumberOfBookPage;
            book.CategoryID = addbook.CategoryID;
            book.BookPrice = addbook.BookPrice;
            book.BookDescription = addbook.BookDescription;
            book.Status = true;

            _bookService.Update(book);
            _myBookshelfContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ActiveBook(int id)
        {
            _bookService.BookStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult PassiveBook(int id)
        {
            _bookService.BookStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
