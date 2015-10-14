using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Api.Controllers
{
    
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private static IMongoDatabase _database = (new MongoClient()).GetDatabase("catalog"); 

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
        public async Task<string> GetByIsbn(string isbn)
        {
            Console.WriteLine($"Got ISBN {isbn}.");
            
            var collection = _database.GetCollection<BsonDocument>("books");
            var filter = Builders<BsonDocument>.Filter.Eq("ISBN", isbn);

            var result = await collection.Find(filter).ToListAsync();
            return result.SingleOrDefault().ToString();                
        }
    }
}
