using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
