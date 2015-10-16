using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http;
using Newtonsoft.Json;


namespace Books.Web.Controllers
{
    public class CatalogController : Controller
    {
        public async Task<IActionResult> Search()
        {
            
            var c = new HttpClient();
            c.BaseAddress = new Uri("http://localhost:5000");
            var d = await c.GetStringAsync("api/books/isbn/0521413230");
            //  JsonConvert.DeserializeObject<List<BookSearchItem>>(d);
            
            
            Console.WriteLine(d);
            return View();
        }
        
        public class BookSearchItem {
            public string ISBN { get; set; }
            public string BookTitle { get; set; }
            public string BookAuthor { get; set; }
            public string YearOfPublication { get; set; }
            public string Publisher { get; set; }
            public string ImageUrlSmall { get; set; }
            public string ImageUrlMedium { get; set; }
            public string ImageUrlLarge { get; set; }
        }
    }
}
