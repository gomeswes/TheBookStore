﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBookStore.Models
{
    public class Review
    {
        public Review()
        {
            Book = new Book();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
        public virtual Book Book { get; set; }
    }
}
