using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Day2MVC.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        [StringLength(20)]
        public string? FirstName { get; set; }
        [StringLength(20)]
        public string? MiddleName { get; set; }
        [StringLength(20)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [Column(TypeName ="money")]
        public double? Salary { get; set; }
        [Column(TypeName ="date")]
        public DateTime Bdate { get; set; }
        [StringLength(20)]
        public string? Sex { get; set; }
        public Employee? Supervisor { get; set; }
        [ForeignKey("Supervisor")]
        public virtual int? ESSN { get; set; }
        public List<Employee>? employees { get; set; }
        public List<Dependent>? dependents { get; set; }
        public List<Works_On>? works_Ons { get; set; }
        public Department? Works_For { get; set; }
        [ForeignKey("Works_For")]
        public virtual int? DeptId { get; set; }
        public Department? Manage { get; set; }
    }
}
