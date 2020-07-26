using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string GearType { get; set; } // M manual A auto T Triptonic
        public string Color { get; set; }
        public int NumberOfSeats { get; set; }
        public int Year { get; set; }
        public string User { get; set; }
    }
}
