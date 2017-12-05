using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id=1,Name="kike's restaurant" };
            //return new ObjectResult(model);//return json(default), xml, csv, pdf, etc, according to the header http request.
            return View(model);
        }
    }
}
