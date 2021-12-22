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
                new Book("BookOne", "WritterOne", 2010, random.Next(200, 500),1),
                new Book("BookTwo", "WritterTwo", 2000, random.Next(200, 500),2),
                new Book("BookThree", "WritterThree", 2003, random.Next(200, 500),3),
                new Book("BookFour", "WritterFour", 2004, random.Next(200, 500),4),
                new Book("BookFive", "WritterFive", 2005, random.Next(200, 500),5),
                new Book("BookSix", "WritterSix", 2006, random.Next(200, 500),6),
                new Book("BookSeven", "WritterSeven", 2007, random.Next(200, 500),7),
                new Book("BookEigth", "WritterEigth", 2008, random.Next(200, 500),8)
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
            ListOfBooks();
            foreach (Book book in bookList)
            {
                if (nameOfBook == book.Name)
                {
                    return Json(book, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("NOT FOUND", JsonRequestBehavior.AllowGet);

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //ListOfBooks();
                //Book bookCreate = new Book("BookNine", "WritterNine", 2009, 900, 9);
                //bookList.Add(bookCreate);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPut]
        // PUT: Person/Edit/5
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
            foreach (Book book in bookList)
            {
                if (id == book.id)
                {
                    bookList.Remove(book);
                    return RedirectToAction("index");
                }
            }
            return Json("NOT FOUND", JsonRequestBehavior.AllowGet);
        }
    }
}
