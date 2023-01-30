using Day2MVC.Models;
using System.ComponentModel.DataAnnotations;
namespace Day2MVC.CustomAttribute
{
    public class ChooseAttribute : ValidationAttribute
    {
        private CompanyDbContext dbContext;
        public ChooseAttribute()
        {
            dbContext = new CompanyDbContext();
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? Location = value as string;
            if (Location == "Cairo"|| Location == "Alex"|| Location == "Giza") return ValidationResult.Success;

            return new ValidationResult("Location is not valid");
        }
    }
}
