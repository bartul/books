

namespace Books.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Mvc;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Books.Web.Model;
    using Microsoft.Framework.Configuration;

    public class CatalogController : Controller
    {
        public CatalogController(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        private IConfigurationRoot _configuration;

        public async Task<IActionResult> Search(string term)
        {
            if (string.IsNullOrEmpty(term)) return View(await _GetApiData<List<BookSearchItem>>("api/books"));
            ViewBag.Term = term;
            return View(await _GetApiData<List<BookSearchItem>>($"api/books/{term}"));
        }
        [HttpPost, ActionName("Search")]
        public IActionResult DoSearch(string searchTerm)
        {
            return RedirectToAction("Search", new { term = searchTerm });
        }
        public async Task<IActionResult> Book(string id)
        {
            return View(await _GetApiData<BookSearchItem>($"api/books/isbn/{id}"));
        }

        private async Task<T> _GetApiData<T>(string requestUri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("AppSettings").GetChildren().Single(i => i.Key == "AppSettings:CatalogApiBaseUrl").Value);
            var json = await client.GetStringAsync(requestUri);

            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
namespace Books.Web.Model
{
    public class BookSearchItem
    {
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
