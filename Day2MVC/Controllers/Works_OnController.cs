using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using Day2MVC.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Day2MVC.Controllers
{
    public class Works_OnController : Controller
    {
        private CompanyDbContext dbContext;
        public Works_OnController()
        {
            dbContext = new CompanyDbContext();
        }
        public IActionResult Index()
        {
            List<Works_On> works_s=dbContext.Works_s.Include(n=>n.emp).Include(n=>n.pro).ToList();
            return View(works_s);
        }

        public IActionResult AddEmployee()
        {
            EmployeeProject employeeProject = new EmployeeProject()
            {
                employees = dbContext.Employees.ToList(),
                projects = dbContext.Projects.Where(n => n.DepartmentId == n.department.Number).ToList(),
            };
            return View(employeeProject);
        }
        public IActionResult Add(Works_On works_, int[] ProNum)
        {
            foreach (var item in ProNum)
            {
                Works_On works = new Works_On();
                works.proNumber = works_.proNumber;
                works.Hours = works_.Hours;
                works.proNumber = item;
                dbContext.Works_s.Add(works);
                dbContext.SaveChanges();
            }
            return View("Index");
        }
    }
}
