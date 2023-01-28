using Day2MVC.Models;

namespace Day2MVC.ViewModels
{
    public class EmployeeProject
    {
        public int EmpId { get; set; }
        public int ProNum { get; set; }
        public List<Employee> employees { get; set; }
        public List<Project> projects { get; set; }
    }
}
