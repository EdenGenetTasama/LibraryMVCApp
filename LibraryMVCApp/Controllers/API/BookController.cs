using LibraryMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVCApp.Controllers.API
{
    public class BookController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            ListOfBooks();
            return Json(bookList, JsonRequestBehavior.AllowGet);
        }

        List<Book> bookList = new List<Book>();
        public void ListOfBooks()
        {
            Random random = new Random();
            Book[] bookArray = new Book[]
            {
                new Book("BookOne", "WritterOne", 2010, random.Next(100, 500),1),
                new Book("BookTwo", "WritterTwo", 2000, random.Next(100, 500),2),
                new Book("BookThree", "WritterThree", 2003, random.Next(100, 500),3),
                new Book("BookFour", "WritterFour", 2004, random.Next(100, 500),4),
                new Book("BookFive", "WritterFive", 2005, random.Next(100, 500),5),
                new Book("BookSix", "WritterSix", 2006, random.Next(100, 500),6),
                new Book("BookSeven", "WritterSeven", 2007, random.Next(100, 500),7),
                new Book("BookEigth", "WritterEigth", 2008, random.Next(100, 500),8)
            };

            this.bookList.AddRange(bookArray);

        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            ListOfBooks();
            foreach (Book book in bookList)
            {
                if (id == book.id)
                {
                    return Json(book, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("NOT FOUND", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult DetailsByName(string nameOfBook)
        {
            try
            {
                List<Book> byName = (from book in bookList
                                     where nameOfBook == book.Name
                                     //orderby book.YearOfOut
                                     select book).ToList();

                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            catch
            {

                return Json("NOT FOUND", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DetailsByWritter(string writterName)
        {
            ListOfBooks();
            foreach (Book book in bookList)
            {
                if (writterName == book.Writter)
                {
                    return Json(book, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("NOT FOUND", JsonRequestBehavior.AllowGet);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Book obj)
        {
            try
            {
                //ListOfBooks();
                //Book bookCreate = new Book("BookNine", "WritterNine", 2009, 900, 9);
                bookList.Add(obj);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return Json("NOT FOUND", JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPut]
        // PUT: Person/Edit/5
        public ActionResult Edit(int id, Book obj)
        {
            try
            {
                var update = from book in bookList
                             where id == book.id
                             select book;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Delete: Person/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                //Book deletePerson = bookList.Find(item => item.id == id);
                bookList.Remove(bookList.Find(item => item.id == id));
                return Json("Removed", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("NOT FOUND", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
