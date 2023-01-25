using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Day2MVC.Models
{
    public class Location
    {
        public string? location { get; set; }
        public Department? department { get; set; }
        [ForeignKey("department")]
        public int? deptNumber { get; set; }
        public virtual List<Location>? locations { get; set; }
        public virtual List<Project>? Projects { get; set; }
    }
}
