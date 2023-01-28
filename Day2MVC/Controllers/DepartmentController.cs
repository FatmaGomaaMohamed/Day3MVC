using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private CompanyDbContext dbContext;
        public DepartmentController()
        {
            dbContext = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            Department departments= dbContext.Departments.Where(e => e.ESSN == HttpContext.Session.GetInt32("SSN")).Include(n=>n.projects).SingleOrDefault();
            HttpContext.Session.SetInt32("DeptId", (int)departments.Number);
            return View(departments);
        }
    }
}
