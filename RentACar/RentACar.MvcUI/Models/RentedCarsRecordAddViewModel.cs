using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class RentedCarsRecordAddViewModel
    {
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string TC { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string State { get; set; }
        [Required] // A for active - P for passive 
        public string User { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<Car> Cars { get; set; }
    }
}
