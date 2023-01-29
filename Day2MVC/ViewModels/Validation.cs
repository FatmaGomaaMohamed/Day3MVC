using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day2MVC.ViewModels
{
    public class Validation
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be more or equal 5 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [Remote("validateName", "CustomValidation", ErrorMessage = "Project must be in Cairo or Alex or Giza")]
        public string Location { get; set; }
        [Compare("Location")]
        public string ConfirmLocation { get; set; }
    }
}
