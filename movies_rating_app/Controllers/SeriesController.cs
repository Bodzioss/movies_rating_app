using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
