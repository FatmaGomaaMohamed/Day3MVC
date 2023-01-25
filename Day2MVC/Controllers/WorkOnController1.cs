using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Controllers
{
    public class WorkOnController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
