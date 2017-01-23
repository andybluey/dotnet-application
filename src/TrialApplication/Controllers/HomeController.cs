using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrialApplication.Entities;
using TrialApplication.Services;
using TrialApplication.ViewModels;

namespace TrialApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)

            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;

                newRestaurant = _restaurantData.Add(newRestaurant);
                _restaurantData.Commit();
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            return View();
        }
    }
}
