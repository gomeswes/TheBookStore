using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookStore.Contracts
{
    public interface IUnityOfWork
    {
        void Commit();
        IBooksRepository Books { get; }
        IAuthorRepository Authors { get; }
        IReviewRepository Reviews { get; }
    }
}
