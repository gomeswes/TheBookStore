using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class BookSampleRepository : IBooksRepository
    {
        public IQueryable<Book> All
        {
            get { return DataBase.Books.AsQueryable<Book>(); }
        }

        public IQueryable<Book> Search(string criteria)
        {
            return DataBase.Books.Where(book => book.Title.Contains(criteria) || book.Description.Contains(criteria)).AsQueryable<Book>();
        }

        public Book GetOne(int id)
        {
            return DataBase.Books.Where(book => book.Id == id).FirstOrDefault();
        }
    }
}