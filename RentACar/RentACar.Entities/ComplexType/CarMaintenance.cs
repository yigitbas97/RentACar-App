using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.ComplexType
{
    public class CarMaintenance : IEntity
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime FutureMaintenanceDate { get; set; }
        public int CarKilometers { get; set; }
        public string User { get; set; }
    }
}
