using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.MvcUI.Models
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public string User { get; set; }
    }
}
