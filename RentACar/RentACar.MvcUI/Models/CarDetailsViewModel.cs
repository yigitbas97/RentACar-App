﻿using RentACar.Entities.ComplexType;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class CarDetailsViewModel
    {
        public Car Car { get; set; }
        public List<RentedCarsRecord> Records { get; set; }
    }
}
