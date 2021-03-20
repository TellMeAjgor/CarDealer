using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.Enums
{
    public enum Conditions
    {
        [Display(Name = "Bad")]
        Bad,
        [Display(Name = "Good")]
        Good,
        [Display(Name = "Excelent")]
        Excelent
    }
}
