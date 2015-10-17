namespace Catalog.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Mvc;
    using MongoDB.Bson;
    using MongoDB.Driver;

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private static ProjectionDefinition<BsonDocument, BsonDocument> excluedId = Builders<BsonDocument>.Projection.Exclude("_id");

    
        public BooksController(IMongoDatabase database) {
            _database = database;
        }
        
        private IMongoDatabase _database; 

             
        // GET: api/books
        [HttpGet]
        public async Task<string> Get()
        {
            var collection = _database.GetCollection<BsonDocument>("books");
            
            var filter = Builders<BsonDocument>.Filter.Not(Builders<BsonDocument>.Filter.Eq("BookTitle", ""));

            
            var result = await collection
                .Find(filter)
                .Project(excluedId)
                .Limit(50)
                .ToListAsync();

            return result.ToJson();                
        }

        // GET api/books/dickens
        [HttpGet("{term}")]
        public async Task<string> Get(string term)
        {
            var collection = _database.GetCollection<BsonDocument>("books");
            var filter = Builders<BsonDocument>.Filter.Text(term);

            var result = await collection
                .Find(filter)
                .Project(excluedId)
                .Limit(50)
                .ToListAsync();
            return result.ToJson();                
        }

        // GET api/books/isbn/4234235
        [HttpGet("isbn/{isbn}")]
        public async Task<string> GetByIsbn(string isbn)
        {
            var collection = _database.GetCollection<BsonDocument>("books");
            var filter = Builders<BsonDocument>.Filter.Eq("ISBN", isbn);

            var result = await collection
                .Find(filter)
                .Project(excluedId)
                .ToListAsync();
            return result.SingleOrDefault().ToJson();                
        }
    }
}
