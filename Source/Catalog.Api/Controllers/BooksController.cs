using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // GET: api/books
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "book 1", "book 2", "book 3" };
        }

        // GET api/books/dickens
        [HttpGet("{term}")]
        public IEnumerable<string> Get(string term)
        {
            return new string[] { "book 1", "book 2", "book 3" };
        }

        // GET api/books/isbn/4234235
        [HttpGet("isbn/{isbn}")]
        public string Get(float isbn)
        {
            return $"Book with ISBN: {isbn}.";
        }
    }
}
