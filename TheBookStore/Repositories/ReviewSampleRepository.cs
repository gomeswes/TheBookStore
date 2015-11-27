using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class ReviewSampleRepository : IReviewRepository
    {
        public IQueryable<Models.Review> All(int bookId)
        {
            return DataBase.Reviews.Where(review => review.Book.Id == bookId).AsQueryable<Review>();
        }

        public Models.Review AddReview(Models.Review book)
        {
            DataBase.Reviews.Add(book);
            return book;
        }

        public Models.Review RemoveReview(int id)
        {
            var item = DataBase.Reviews.Where(review => review.Id == id).FirstOrDefault();
            if (item != null)
                DataBase.Reviews.Remove(item);

            return item;
        }
    }
}