using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    public class SeasonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
