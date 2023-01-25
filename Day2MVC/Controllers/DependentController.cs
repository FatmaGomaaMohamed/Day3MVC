using Microsoft.AspNetCore.Mvc;
using Day2MVC.Models;

namespace Day2MVC.Controllers
{
    public class DependentController : Controller
    {
        private CompanyDbContext dbContext;
        public DependentController()
        {
            dbContext = new CompanyDbContext();
        }
        public IActionResult GetAll()
        {
            List<Dependent> dependents = dbContext.Dependents.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).ToList();
            return View("GetAll", dependents);
        }
        public IActionResult AddDependence(int id)
        {
            return View("AddDependence");
        }

        public IActionResult Add(Dependent dep)
        {
            dbContext.Dependents.Add(dep);
            dbContext.SaveChanges();
            TempData["msg"] = "You Add one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(int id)
        {
            Dependent dep = dbContext.Dependents.Where(e => e.SSN == id).Single();
            return View("Edit", dep);
        }
        public IActionResult Delete(int id)
        {
            Dependent dep = dbContext.Dependents.Where(e => e.SSN == id).Single();
            dbContext.Dependents.Remove(dep);
            dbContext.SaveChanges();
            TempData["msg"] = "You Delete one Dependent";
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(Dependent dep)
        {
            var Olddep = dbContext.Dependents.SingleOrDefault(e => e.SSN == dep.SSN);
            Olddep.Name = dep.Name;
            Olddep.BirthDate = dep.BirthDate;
            Olddep.Relationship = dep.Relationship;
            Olddep.SSN = HttpContext.Session.GetInt32("SSN");
            dbContext.SaveChanges();
            TempData["msg"] = "You Update one Dependent";
            return RedirectToAction("GetAll");
        }
    }
}
