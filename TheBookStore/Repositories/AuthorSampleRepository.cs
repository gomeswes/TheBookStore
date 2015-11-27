using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class AuthorSampleRepository : IAuthorRepository
    {
        
        public IQueryable<Author> All
        {
            get { return DataBase.Authors.AsQueryable(); }
        }
    }
}