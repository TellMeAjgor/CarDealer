using System.ComponentModel.DataAnnotations;
using CarDealer.Models.Enums;

namespace CarDealer.Models.View
{
    public class ClientVM
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name can't be larger than 30 characters")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Surname can't be larger than 30 characters")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must have 11 characters(with area code)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 200, ErrorMessage = "Age can't be larger than 200")]
        public short Age { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "City can't be larger than 30 characters")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; }
    }
}