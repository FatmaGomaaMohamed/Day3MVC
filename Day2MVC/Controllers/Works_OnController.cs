using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using Day2MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [HttpGet]
        public IActionResult EditEmpHour()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            ViewBag.Employees = new SelectList(employees, "SSN", "FirstName");
            return View();
        }

        public IActionResult EditEmpHour_emp(int id)
        {
            List<Project> projects = dbContext.Works_s.Include(s => s.pro)
                .Where(m => m.ESSN == id).Select(n => n.pro).ToList();
            ViewBag.Projects = new SelectList(projects, "PNumber", "PName");
            if (projects.Count > 0)
            {
                Works_On works = new Works_On()
                {
                    Hours = dbContext.Works_s.SingleOrDefault(s => (s.ESSN == id) && (s.proNumber == projects[0].PNumber)).Hours,
                };
                return PartialView("_ProjectsList", works);
            }
            return PartialView("_ProjectsList");
        }

        public IActionResult EditEmpHour_empPro(int id, int pnumber)
        {
            Works_On? works = dbContext.Works_s.SingleOrDefault(s => (s.ESSN == id) && (s.proNumber == pnumber));
            if (works == null) return View("Error");
            return PartialView("_hour", works);
        }
        [HttpPost]
        public IActionResult EditEmpHour(Works_On works_)
        {
            if (ModelState.IsValid)
            {
                dbContext.Works_s.Update(works_);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
