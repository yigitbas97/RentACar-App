using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.MvcUI.Models;

namespace RentACar.MvcUI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private IRentedCarsRecordService _rentedCarsRecordService;
        public CustomerController(ICustomerService customerService, IRentedCarsRecordService rentedCarsRecordService)
        {
            _customerService = customerService;
            _rentedCarsRecordService = rentedCarsRecordService;
        }

        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name.ToString();
            var customers = _customerService.GetAll().Where(p => p.User == user).ToList();

            var model = new CustomerListViewModel
            {
                Customers = customers,
                User = user
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var user = HttpContext.User.Identity.Name.ToString();
            var model = new CustomerAddViewModel();

            model.User = user;

            model.GenderList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Male", Value = "M"},
                new SelectListItem {Text = "Female", Value = "F"},
            };

            model.DriverLicenceList = new List<SelectListItem>
            {
                new SelectListItem {Text = "M", Value = "M"},
                new SelectListItem {Text = "A1", Value = "A1"},
                new SelectListItem {Text = "A2", Value = "A2"},
                new SelectListItem {Text = "A", Value = "A"},
                new SelectListItem {Text = "B1", Value = "B1"},
                new SelectListItem {Text = "B", Value = "B"},
                new SelectListItem {Text = "BE", Value = "BE"},
                new SelectListItem {Text = "C1", Value = "C1"},
                new SelectListItem {Text = "C1E", Value = "C1E"},
                new SelectListItem {Text = "C", Value = "C"},
                new SelectListItem {Text = "CE", Value = "CE"},
                new SelectListItem {Text = "D1", Value = "D1"},
                new SelectListItem {Text = "D1E", Value = "D1E"},
                new SelectListItem {Text = "D", Value = "D"},
                new SelectListItem {Text = "DE", Value = "DE"},
                new SelectListItem {Text = "F", Value = "F"},
                new SelectListItem {Text = "G", Value = "G"}
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var addedCustomer = _customerService.GetByTC(customer.TC);

                if (addedCustomer != null)
                {
                    TempData["message"] = "TC number already registered in database !";
                    return RedirectToAction("Index", "Customer");
                }

                _customerService.Add(customer);

                TempData["message"] = "New customer added to database succesfully !";
                return RedirectToAction("Index", "Customer");
            }

            TempData["message"] = "New customer could not add to database !";
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Details(int customerId)
        {
            var customer = _customerService.GetById(customerId);

            if (customer != null)
            {
                var records = _rentedCarsRecordService.GetByUserTC(customer.TC);
                var model = new CustomerDetailsViewModel { Customer = customer, Records=records };
                return View(model);
            }

            TempData["message"] = "Failed to reach detail page !";
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult Update(int customerId)
        {
            var customer = _customerService.GetById(customerId);

            if (customer != null)
            {
                var model = new CustomerUpdateViewModel();
                model.Id = customer.Id;
                model.User = HttpContext.User.Identity.Name.ToString();
                model.TC = customer.TC;
                model.Name = customer.Name;
                model.Surname = customer.Surname;
                model.BirthDate = customer.BirthDate;
                model.Gender = customer.Gender;
                model.EMail = customer.EMail;
                model.Address = customer.Address;
                model.PhoneNumber = customer.PhoneNumber;
                model.PhoneNumber2 = customer.PhoneNumber2;
                model.DriverLicence = customer.DriverLicence;
                model.GenderList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Male", Value = "M"},
                    new SelectListItem {Text = "Female", Value = "F"},
                };

                model.DriverLicenceList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "M", Value = "M"},
                    new SelectListItem {Text = "A1", Value = "A1"},
                    new SelectListItem {Text = "A2", Value = "A2"},
                    new SelectListItem {Text = "A", Value = "A"},
                    new SelectListItem {Text = "B1", Value = "B1"},
                    new SelectListItem {Text = "B", Value = "B"},
                    new SelectListItem {Text = "BE", Value = "BE"},
                    new SelectListItem {Text = "C1", Value = "C1"},
                    new SelectListItem {Text = "C1E", Value = "C1E"},
                    new SelectListItem {Text = "C", Value = "C"},
                    new SelectListItem {Text = "CE", Value = "CE"},
                    new SelectListItem {Text = "D1", Value = "D1"},
                    new SelectListItem {Text = "D1E", Value = "D1E"},
                    new SelectListItem {Text = "D", Value = "D"},
                    new SelectListItem {Text = "DE", Value = "DE"},
                    new SelectListItem {Text = "F", Value = "F"},
                    new SelectListItem {Text = "G", Value = "G"}
                };

                return View(model);
            }

            TempData["message"] = "Failed to reach update page !";
            return RedirectToAction("Index", "Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(customer);

                TempData["message"] = "Your customer updated successfully !";
                return RedirectToAction("Index", "Customer");
            }

            TempData["message"] = "Your customer could not update !";
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Delete(int customerId)
        {
            var customer = _customerService.GetById(customerId);

            if (customer != null)
            {
                _customerService.Delete(customerId);

                TempData["message"] = "Your selected customer deleted from database succesfully!";
                return RedirectToAction("Index", "Customer");
            }

            TempData["message"] = "Your customer could not delete from database !";
            return RedirectToAction("Index", "Customer");
        }
    }
}