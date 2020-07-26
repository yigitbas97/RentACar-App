using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class RentedCarsRecordListViewModel
    {
        public List<RentedCarsRecord> RentedCarsRecords { get; set; }
        public string User { get; set; }
    }
}
