using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            //var model = new Restaurant { Id=1,Name="kike's restaurant" };
            //return new ObjectResult(model);//return json(default), xml, csv, pdf, etc, according to the header http request.
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}
