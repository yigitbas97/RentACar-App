using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class CarListViewModel
    {
        public string User { get; set; }
        public List<Car> Cars { get; set; }
    }
}
