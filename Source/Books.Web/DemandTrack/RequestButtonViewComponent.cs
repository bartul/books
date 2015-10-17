using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Books.Web.DemandTrack
{
    public class RequestButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string bookId)
        {
            return View(new RequestButtonViewModel { BookId = bookId });
        }
    }
    public class RequestButtonViewModel
    {
        public string BookId { get; set; }
    }
}
