using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class CarUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string GearType { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required(ErrorMessage = "Minimum year can entries 1950")]
        [Range(1950, Int32.MaxValue),]
        public int Year { get; set; }
        [Required]
        public string User { get; set; }

        public List<SelectListItem> TypeList { get; set; }
        [Required]
        public List<SelectListItem> GearTypeList { get; set; }
        [Required]
        public List<SelectListItem> ColorList { get; set; }
        [Required]
        public List<SelectListItem> NumberOfSeatsList { get; set; }
    }
}
