using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.ComplexType
{
    public class RentedCarsRecord : IEntity
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string TC { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string State { get; set; } // A for active - P for passive 
        public string User { get; set; }
    }
}
