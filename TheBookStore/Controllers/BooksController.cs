using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBookStore.Contracts;
using TheBookStore.Datastores;
using TheBookStore.App_Start;
using TheBookStore.DataTransferObjects;

namespace TheBookStore.Controllers
{
    public class BooksController : ApiController
    {
        private IUnityOfWork _unity;

        public BooksController()
        {
            _unity = new SampleDataStore();
        }

        public IHttpActionResult Get()
        {
            var books = _unity.Books.All;
            if (books == null)
            {
                return NotFound();
            }
            var response = books.To<BookDto>();
            return Ok(response);
        }

        public IHttpActionResult Get(string query)
        {
            var books = _unity.Books.Search(query);
            if (books == null)
            {
                return NotFound();
            }
            var response = books.To<BookDto>();
            return Ok(response);
        }

        public IHttpActionResult Get(int id)
        {
            var book = _unity.Books.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }
            var response = book.To<BookDto>();
            return Ok(response);
        }
    }
}
