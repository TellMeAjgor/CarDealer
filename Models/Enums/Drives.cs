using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models.Enums
{
    public enum Drives
    {
        [Display(Name = "FWD")]
        FWD,
        [Display(Name = "RWD")]
        RWD,
        [Display(Name = "AWD")]
        AWD,
        [Display(Name = "4WD")]
        FourWD
    }
}
