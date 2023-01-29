using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Day2MVC.ViewModels;
using Day2MVC.Models;

namespace Day2MVC.Controllers
{
    public class ValidationController : Controller
    {
        private CompanyDbContext dbContext;
        public ValidationController()
        {
            dbContext = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            List <Project> projects= dbContext.Projects.ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Validation validation)
        {
            if(!(validation.Location.Contains("Cairo"))|| !(validation.Location.Contains("Alex"))|| !(validation.Location.Contains("Giza")))
            {
                ModelState.AddModelError("", "Project must be in Cairo or Alex or Giza");
            }
            if (ModelState.IsValid)
            {
                Project project = new Project()
                {
                    PName = validation.Name,
                    Loc = validation.Location
                };
                dbContext.Projects.Add(project);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
