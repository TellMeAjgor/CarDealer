using CarDealer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.View
{
    public class CarVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Brand can be no larger than 30 characters")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Model can be no larger than 30 characters")]
        public string Model { get; set; }
        [Required(ErrorMessage = "HorsePower is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be bigger then 0")]
        public int HorsePower { get; set; }
        [Required(ErrorMessage = "Mileage is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be bigger then 0")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Vin is required")]
        [MaxLength(17)]
        public string Vin { get; set; }
        [Required(ErrorMessage = "Condition is required")]
        public Conditions Condition { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [MaxLength(4)]
        public string Year { get; set; }
        [Required(ErrorMessage = "Color is required")]
        [MaxLength(20)]
        public string Color { get; set; }
        [Required(ErrorMessage = "Drive is required")]
        public Drives Drive { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
