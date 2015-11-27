using System.Collections.Generic;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{

    internal static class DataBase
    {
        public static IList<Book> Books { get; private set; }
        public static IList<Author> Authors { get; private set; }
        public static IList<Review> Reviews { get; private set; }
        
        static DataBase()
        {

            Authors = new List<Author>{
                new Author {Id = 1, Name = "Stefan", Surname= "Jonck"},
                new Author { Id = 2, Name = "Claudio", Surname = "Vzzini"},
                new Author { Id = 3, Name = "Jaco", Surname = "Visser"}
            };

            Books = new List<Book>
            {
                new Book { Id = 1, Title= "Wedding Bells", Authors = new List<Author>{ Authors[0] } },
                new Book { Id = 2, Title = "The truth about cricket", Authors = new List<Author> { Authors[0] }},
                new Book { Id = 3, Title = "The fine art of Italian cooking", Authors = new List<Author> { Authors[1] } },
                new Book { Id = 4, Title = "Another day in Europe", Authors = new List<Author> { Authors[1] }},
                new Book { Id = 5, Title = "SQL for begginers", Authors = new List<Author>{ Authors[2] } }
            };
            Authors[0].Books.Add(Books[0]);
            Authors[0].Books.Add(Books[1]);
            Authors[1].Books.Add(Books[2]);
            Authors[1].Books.Add(Books[3]);
            Authors[2].Books.Add(Books[4]);


            Reviews = new List<Review>
            {
                new Review { Id = 1, Book = Books[0], Feedback = "Good", Name = "Nice reading", Rating = 3 },
                new Review { Id = 2, Book = Books[1], Feedback = "Not much interesting", Name="Not recomended", Rating = 1 },
                new Review { Id = 3, Book = Books[2], Feedback = "Good", Name = "Tasty!", Rating = 4}
            };


        }




    }

}