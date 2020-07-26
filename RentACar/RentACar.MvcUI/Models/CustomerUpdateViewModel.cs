using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class CustomerUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string TC { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; } // M or F
        public string EMail { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        [Required]
        public string DriverLicence { get; set; }
        [Required]
        public string User { get; set; }

        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> DriverLicenceList { get; set; }
    }
}
