using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Repositories;

namespace TheBookStore.Datastores
{
    public class SampleDataStore : IUnityOfWork
    {
        private IBooksRepository _books;
        private IAuthorRepository _authors;
        private IReviewRepository _reviews;

        public void Commit()
        {

        }

        public IBooksRepository Books
        {
            get
            {
                if (_books == null)
                {
                    _books = new BookSampleRepository();
                }

                return _books;
            }
        }

        public IAuthorRepository Authors
        {
            get {
                if (_authors == null)
                {
                    _authors = new AuthorSampleRepository();
                }

                return _authors;
            }
        }

        public IReviewRepository Reviews
        {
            get {
                if (_reviews == null) {
                    _reviews = new ReviewSampleRepository();
                }

                return _reviews;
            }
        }
    }
}