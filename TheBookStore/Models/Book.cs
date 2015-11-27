﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
            Reviews = new List<Review>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}