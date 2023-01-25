using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Day2MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyDbContext dbContext;
        public EmployeeController()
        {
            dbContext = new CompanyDbContext();
        }

        public IActionResult Index()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View("Index",employees);
        }

        public IActionResult GetById(int id)
        {
            Employee? employee = dbContext.Employees.SingleOrDefault(e => e.SSN == id);
            if (employee == null)
            {
                return View("Error");
            }
            return View(employee);
        }

        public IActionResult Add()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            List<Employee> employees = dbContext.Employees.ToList();
            return View("Index", employees);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = dbContext.Employees.SingleOrDefault(e => e.SSN == id);
            List<Employee> employees = dbContext.Employees.ToList();
            ViewBag.ins = employees;
            return View(employee);
        }

        public IActionResult EditEmployee(Employee employee)
        {
            Employee employeee = dbContext.Employees.SingleOrDefault(e => e.SSN == employee.SSN);
            employeee.FirstName = employee.FirstName;
            employeee.LastName = employee.LastName;
            employeee.Salary = employee.Salary;
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Employee employee = dbContext.Employees.SingleOrDefault(e => e.SSN == id);
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View("Login");

        }
        public IActionResult Check(Employee emp)
        {
            Employee e = dbContext.Employees.Where(e => e.SSN == emp.SSN && e.FirstName == emp.FirstName).Single();                          
                HttpContext.Session.SetInt32("SSN", e.SSN);
                HttpContext.Session.SetString("FirstName", e.FirstName);
                return RedirectToAction("Profile");
        }
        public IActionResult Profile()
        {
            Employee emp = dbContext.Employees.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).Single();
            return View("Profile", emp);
        }
    }
}
