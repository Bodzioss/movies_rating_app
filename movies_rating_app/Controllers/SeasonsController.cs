using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    public class SeasonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
