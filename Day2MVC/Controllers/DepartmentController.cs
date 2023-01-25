using Microsoft.AspNetCore.Mvc;

namespace Day2MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
