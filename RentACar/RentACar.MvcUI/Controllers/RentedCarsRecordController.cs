using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.Business.Abstract;
using RentACar.Entities.ComplexType;
using RentACar.Entities.Concrete;
using RentACar.MvcUI.Models;

namespace RentACar.MvcUI.Controllers
{
    [Authorize]
    public class RentedCarsRecordController : Controller
    {
        private IRentedCarsRecordService _rentedCarsRecordService;
        private ICustomerService _customerService;
        private ICarService _carService;
        public RentedCarsRecordController(IRentedCarsRecordService rentedCarsRecordService, ICustomerService customerService, ICarService carService)
        {
            _rentedCarsRecordService = rentedCarsRecordService;
            _customerService = customerService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name.ToString();
            //Active records filter
            var records = _rentedCarsRecordService.GetAll().Where(p => p.User == user && p.State == "A").ToList();

            var model = new RentedCarsRecordListViewModel
            {
                RentedCarsRecords = records,
                User = user
            };

            return View(model);
        }

        public IActionResult GoCarDetails(string carPlateNumber)
        {
            var car = _carService.GetByPlateNumber(carPlateNumber);

            if (car != null)
            {
                return RedirectToAction("Details", "Car", new { carId = car.Id });
            }

            TempData["message"] = "Failed to reach car detail page";
            return RedirectToAction("Index", "RentedCarsRecord");
        }

        public IActionResult GoCustomerDetails(string customerTC)
        {
            var customer = _customerService.GetByTC(customerTC);

            if (customer != null)
            {
                return RedirectToAction("Details", "Customer", new { customerId = customer.Id });
            }

            TempData["message"] = "Failed to reach customer detail page";
            return RedirectToAction("Index", "RentedCarsRecord");
        }

        public IActionResult TakeDelivery(int rentedCarsRecordId)
        {
            var record = _rentedCarsRecordService.GetById(rentedCarsRecordId);

            if (record != null)
            {
                record.State = "P";
                _rentedCarsRecordService.Update(record);

                TempData["message"] = "Car received succesfully !";
                return RedirectToAction("Index", "RentedCarsRecord");
            }

            TempData["message"] = "Car could not receive !";
            return RedirectToAction("Index", "RentedCarsRecord");
        }

        public IActionResult SelectDate()
        {
            var user = HttpContext.User.Identity.Name.ToString();
            var model = new RentedCarsRecordSelectDateViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(RentedCarsRecordSelectDateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EndDate < model.StartDate || model.StartDate < DateTime.Now)
                {
                    TempData["message"] = "Invalid date";
                    return RedirectToAction("SelectDate","RentedCarsRecord");
                }

                var user = HttpContext.User.Identity.Name.ToString();
                var customers = _customerService.GetAll().Where(p=>p.User == user).ToList();

                //Records with state = A
                var records = _rentedCarsRecordService.GetAll().Where(p => p.User == user && p.State == "A").ToList();
                //Suitable cars in records
                var suitableCars = _rentedCarsRecordService.GetDateByRange(model.StartDate, model.EndDate).Where(p=>p.User == user && p.State == "A").ToList();

                //----------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------
                
                // Unsuitable cars list
                var unsuitableCarsPlateNumber = new List<string>();
                bool flag = false;
                
                for (int i = 0; i < records.Count; i++)
                {
                    for (int j = 0; j < suitableCars.Count; j++)
                    {
                        if (records[i].PlateNumber == suitableCars[j].PlateNumber)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        unsuitableCarsPlateNumber.Add(records[i].PlateNumber);
                    }

                    flag = false;
                }

                //----------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------
                
                // All cars
                var allCars = _carService.GetAll().Where(p=>p.User == user).ToList(); // all cars list
                var allCarsPlateNumber = new List<string>();

                foreach (var car in allCars)
                {
                    allCarsPlateNumber.Add(car.PlateNumber);
                }

                // Suitable cars list
                var suitableCarsPlateNumber = new List<string>();
                bool _flag = false;

                for (int i = 0; i < allCarsPlateNumber.Count; i++)
                {
                    for (int j = 0; j < unsuitableCarsPlateNumber.Count; j++)
                    {
                        if (allCarsPlateNumber[i] == unsuitableCarsPlateNumber[j])
                        {
                            _flag = true;
                            break;
                        }
                    }

                    if (_flag == false)
                    {
                        suitableCarsPlateNumber.Add(allCarsPlateNumber[i]);
                    }

                    _flag = false;
                }

                //----------------------------------------------------------------------------------------
                //----------------------------------------------------------------------------------------

                // All suitableCarsInformations
                var suitableCarsInformations = new List<Car>();

                foreach (var plateNumber in suitableCarsPlateNumber)
                {
                    suitableCarsInformations.Add(allCars.Find(p => p.PlateNumber == plateNumber));
                }

                // All customers information
                List<SelectListItem> customersList = new List<SelectListItem>();

                foreach (var customer in customers)
                {
                    customersList.Add(new SelectListItem { Text = customer.TC + "-" + customer.Name + " " + customer.Surname, Value = customer.TC });
                }

                // Add View Model
                var addModel = new RentedCarsRecordAddViewModel();
                addModel.User = user;
                addModel.State = "A";
                addModel.StartDate = model.StartDate;
                addModel.EndDate = model.EndDate;
                addModel.Customers = customersList;
                addModel.Cars = suitableCarsInformations;

                return View(addModel);
            }

            TempData["message"] = "Failed to reach add page !";
            return RedirectToAction("Index", "RentedCarsRecord");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RentedCarsRecord record)
        {
            if (ModelState.IsValid)
            {
                var addedRecord = _rentedCarsRecordService.GetById(record.Id);

                if (addedRecord != null)
                {
                    TempData["message"] = "This record already added to database !";
                    return RedirectToAction("Index", "RentedCarRecord");
                }

                _rentedCarsRecordService.Add(record);

                TempData["message"] = "Record added to database succesfully !";
                return RedirectToAction("Index", "RentedCarsRecord");
            }

            return View();
        }
    }
}