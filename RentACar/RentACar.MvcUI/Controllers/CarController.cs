using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.MvcUI.Models;

namespace RentACar.MvcUI.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private ICarService _carService;
        private IRentedCarsRecordService _rentedCarsRecordService;
        public CarController(ICarService carService, IRentedCarsRecordService rentedCarsRecordService)
        {
            _carService = carService;
            _rentedCarsRecordService = rentedCarsRecordService;
        }

        public IActionResult Index()
        {
            string user = HttpContext.User.Identity.Name.ToString();
            var cars = _carService.GetAll().Where(p => p.User == user).ToList();

            var model = new CarListViewModel
            {
                User = user,
                Cars = cars
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            string user = HttpContext.Session.GetString("userName");

            var model = new CarAddViewModel();

            model.User = HttpContext.User.Identity.Name.ToString();
            model.TypeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "SUV", Value = "SUV"},
                new SelectListItem {Text = "SEDAN", Value = "SEDAN"},
                new SelectListItem {Text = "HATCHBACK", Value = "HATCHBACK"}
            };
            model.GearTypeList = new List<SelectListItem>
            {
                new SelectListItem{Text="Manual", Value="M"},
                new SelectListItem{Text="Automatic", Value="A"},
                new SelectListItem{Text="Triptonic", Value="T"}
            };
            model.ColorList = new List<SelectListItem>
            {
                new SelectListItem{Text="White", Value="White"},
                new SelectListItem{Text="Black", Value="Black"},
                new SelectListItem{Text="Blue", Value="Blue"},
                new SelectListItem{Text="Red", Value="Red"},
                new SelectListItem{Text="Grey", Value="Grey"},
                new SelectListItem{Text="Green", Value="Green"},
                new SelectListItem{Text="Dark Blue", Value="Dark Blue"},
            };
            model.NumberOfSeatsList = new List<SelectListItem>
            {
                new SelectListItem{Text="2", Value="2"},
                new SelectListItem{Text="5", Value="5"},
                new SelectListItem{Text="7", Value="7"},
                new SelectListItem{Text="10", Value="10"},
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                var addedCar = _carService.GetByPlateNumber(car.PlateNumber);

                if (addedCar != null)
                {
                    TempData.Add("message", "Plate number already registered in database");
                    return RedirectToAction("Index", "Car");
                }

                _carService.Add(car);

                TempData["message"] = "New car added to database";
                return RedirectToAction("Index", "Car");
            }

            TempData["message"] = "New car could not add to database";
            return RedirectToAction("Index", "Car");
        }

        public IActionResult Details(int carId)
        {
            var car = _carService.GetById(carId);

            if (car != null)
            {
                var records = _rentedCarsRecordService.GetByCarPlateNumber(car.PlateNumber);
                var model = new CarDetailsViewModel { Car = car, Records = records };
                return View(model);
            }

            TempData["message"] = "Failed to reach detail page !";
            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        public IActionResult Update(int carId)
        {
            var updatedCar = _carService.GetById(carId);

            if (updatedCar != null)
            {
                var model = new CarUpdateViewModel();
                model.Id = updatedCar.Id;
                model.User = HttpContext.User.Identity.Name.ToString();
                model.PlateNumber = updatedCar.PlateNumber;
                model.Brand = updatedCar.Brand;
                model.Model = updatedCar.Model;
                model.Year = updatedCar.Year;
                model.Type = updatedCar.Type;
                model.GearType = updatedCar.GearType;
                model.Color = updatedCar.Color;
                model.NumberOfSeats = updatedCar.NumberOfSeats;

                model.TypeList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "SUV", Value = "SUV"},
                    new SelectListItem {Text = "SEDAN", Value = "SEDAN"},
                    new SelectListItem {Text = "HATCHBACK", Value = "HATCHBACK"}
                };
                model.GearTypeList = new List<SelectListItem>
                {
                    new SelectListItem{Text="Manual", Value="M"},
                    new SelectListItem{Text="Automatic", Value="A"},
                    new SelectListItem{Text="Triptonic", Value="T"}
                };
                model.ColorList = new List<SelectListItem>
                {
                    new SelectListItem{Text="White", Value="White"},
                    new SelectListItem{Text="Black", Value="Black"},
                    new SelectListItem{Text="Blue", Value="Blue"},
                    new SelectListItem{Text="Red", Value="Red"},
                    new SelectListItem{Text="Grey", Value="Grey"},
                    new SelectListItem{Text="Green", Value="Green"},
                    new SelectListItem{Text="Dark Blue", Value="Dark Blue"},
                };
                model.NumberOfSeatsList = new List<SelectListItem>
                {
                    new SelectListItem{Text="2", Value="2"},
                    new SelectListItem{Text="5", Value="5"},
                    new SelectListItem{Text="7", Value="7"},
                    new SelectListItem{Text="10", Value="10"},
                };

                return View(model);
            }

            TempData["message"] = "Failed to reach update page !";
            return RedirectToAction("Index", "Car");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(car);

                TempData["message"] = "Your car updated successfully !";
                return RedirectToAction("Index", "Car");
            }

            TempData["message"] = "Your car could not update !";
            return RedirectToAction("Index", "Car");
        }

        public IActionResult Delete(int carId)
        {
            var deletedCar = _carService.GetById(carId);

            if (deletedCar != null)
            {
                _carService.Delete(carId);

                TempData["message"] = "Your selected car deleted from database !";
                return RedirectToAction("Index", "Car");
            }

            TempData["message"] = "Your car could not delete !";
            return RedirectToAction("Index", "Car");
        }
    }
}