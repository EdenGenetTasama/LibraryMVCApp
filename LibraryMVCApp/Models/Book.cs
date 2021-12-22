using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVCApp.Models
{
    public class Book
    {
        public string Name;
        public string Writter;
        public int YearOfOut;
        public int NumberPages;
        public int id;
        public Book(string _name , string _writter , int _yearOfOut , int _numberPages, int _id)
        {
            this.id = _id;
            this.Name = _name;
            this.Writter = _writter;
            this.YearOfOut = _yearOfOut;
            this.NumberPages = _numberPages;
        }
        public Book()
        {

        }
 



    }
}