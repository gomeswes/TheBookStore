using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBookStore.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname
        {
            get
            {
                return Name + " " +  Surname;
            }
        }
        public virtual ICollection<Book> Books { get; set; }
    }
}