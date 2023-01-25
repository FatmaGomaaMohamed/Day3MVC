using System.ComponentModel.DataAnnotations.Schema;

namespace Day2MVC.Models
{
    public class Works_On
    {
        public int Hours { get; set; }
        public virtual Employee? emp { get; set; }
        [ForeignKey("emp")]
        public int? ESSN { get; set; }
        public virtual Project? pro { get; set; }
        [ForeignKey("pro")]
        public int? proNumber { get; set; }

    }
}
