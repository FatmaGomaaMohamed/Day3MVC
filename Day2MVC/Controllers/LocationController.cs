using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
