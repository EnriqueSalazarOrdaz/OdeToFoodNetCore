using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels.Home;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData
                              ,IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        [HttpGet]
        [ActionName("Index")]    
        public IActionResult Index()
        {
            //var model = new Restaurant { Id=1,Name="kike's restaurant" }; //using simple class
            //return new ObjectResult(model);//return json(default), xml, csv, pdf, etc, according to the header http request.
            //var model = _restaurantData.GetAll(); //using a model
            var model = new HomeIndexViewModel();     //using a viewModel
            model.Restaurants = _restaurantData.GetAll(); //populate ViewModel using services that already existed
            model.CurrentMessage = _greeter.GetMessage(); //populate ViewModel using services that already existed
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model==null)
            {
                //return NotFound();
                //return RedirectToAction("Index", "Home");
                return RedirectToAction(nameof(Index),"Home");//better because if you rename Index Action using decoration is more mantainable.
            }
            return View(model);
        }
    }
}
