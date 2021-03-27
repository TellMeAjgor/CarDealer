using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models.Enums
{
    public enum Sex
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Other")]
        Other,
    }
}