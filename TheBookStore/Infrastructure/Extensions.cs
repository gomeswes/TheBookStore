using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.DataTransferObjects;

namespace TheBookStore.Infrastructure
{
    public static class Extensions
    {
        public static string Flatten(this BookDto book)
        {
            var flatBook = new { 
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors.AsString(" - ")
            };

            return string.Format("{0},{1},{2}", flatBook.Id, flatBook.Title, flatBook.Authors);
        }
        public static string AsString(this IEnumerable<object> collection, string separator)
        {
            return string.Join(separator, collection.Select(item => item.ToString()).ToArray());
        }

    }
}