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
using TheBookStore.Models;

namespace TheBookStore.Controllers
{
    public class ReviewController : ApiController
    {
        private IUnityOfWork _unity;

        public ReviewController()
        {
            _unity = new SampleDataStore();
        }

        public IHttpActionResult Get(int bookId)
        {
            var result = _unity.Reviews.All(bookId);
            if (result == null)
            {
                return NotFound();
            }
            var response = result.To<ReviewDto>();
            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Review review, int bookId)
        {
            review.Book.Id = bookId;
            var newReview = _unity.Reviews.AddReview(review);
            _unity.Commit();

            var url = Url.Link("DefaultApi", new { controller = "Reviews", id = newReview.Id });
            return Created(url, newReview);
        }

        public IHttpActionResult Delete(int id)
        {
            _unity.Reviews.RemoveReview(id);
            _unity.Commit();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
