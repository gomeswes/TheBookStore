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

namespace TheBookStore.Controllers
{
    public class AuthorsController : ApiController
    {
        private IUnityOfWork _unity;

        public AuthorsController(IUnityOfWork unity)
        {
            _unity = unity;
        }

        public IHttpActionResult Get()
        {
            var authors = _unity.Authors.All;
            if (authors == null)
            {
                return NotFound();
            }
            var response = authors.To<AuthorDto>();
            return Ok(response);
        }
    }
}
