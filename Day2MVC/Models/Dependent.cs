using System.ComponentModel.DataAnnotations.Schema;

namespace Day2MVC.Models
{
    public class Dependent
    {
        public string? Name { get; set; }
        public string? Sex { get; set; }
        [Column(TypeName ="date")]
        public DateTime BirthDate { get; set; }
        public string? Relationship { get; set; }
        [ForeignKey("emp")]
        public int? SSN { get; set; }
        public virtual Employee? emp { get; set; }
        
    }
}
