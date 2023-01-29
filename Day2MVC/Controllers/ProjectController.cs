using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Day2MVC.ViewModels;

namespace Day2MVC.Controllers
{
    public class ProjectController : Controller
    {
        private CompanyDbContext dbContext;
        public ProjectController()
        {
            dbContext = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            List<Project> project=dbContext.Projects.ToList();
            return View(project);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Department>departments = dbContext.Departments.ToList();
            ViewBag.Departments = new SelectList(departments,"Number","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Project project)
        {
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
