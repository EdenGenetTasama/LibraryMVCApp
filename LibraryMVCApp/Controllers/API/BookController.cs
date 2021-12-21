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
                new Book("BookOne", "WritterOne", 2010, random.Next(200, 500)),
                new Book("BookTwo", "WritterTwo", 2000, random.Next(200, 500)),
                new Book("BookThree", "WritterThree", 2003, random.Next(200, 500)),
                new Book("BookFour", "WritterFour", 2004, random.Next(200, 500)),
                new Book("BookFive", "WritterFive", 2005, random.Next(200, 500)),
                new Book("BookSix", "WritterSix", 2006, random.Next(200, 500)),
                new Book("BookSeven", "WritterSeven", 2007, random.Next(200, 500)),
                new Book("BookEigth", "WritterEigth", 2008, random.Next(200, 500))
            };

            this.bookList.AddRange(bookArray);

        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            ListOfBooks();
            foreach (Book book in this.bookList)
            {
                if (id == book.id)
                {
                    return Json(book, JsonRequestBehavior.AllowGet);
                }
                //else
                //{
                //}
                
            }
                    return Json("NOT FOUND", JsonRequestBehavior.AllowGet);

        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
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
            return View();
        }
    }
}
