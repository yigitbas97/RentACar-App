using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(int carId)
        {
            _carDal.Delete(new Car { Id = carId });
        }

        public List<Car> GetAll()
        {
            return _carDal.GetList();
        }

        public List<Car> GetByBrand(string brand)
        {
            return _carDal.GetList(p => p.Brand == brand);
        }

        public List<Car> GetByColor(string color)
        {
            return _carDal.GetList(p => p.Color == color);
        }

        public List<Car> GetByGearType(string gearType)
        {
            return _carDal.GetList(p => p.GearType == gearType);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(p => p.Id == carId);
        }

        public List<Car> GetByModel(string carModel)
        {
            return _carDal.GetList(p => p.Model == carModel);
        }

        public List<Car> GetByNumberOfSeats(int numberOfSeats)
        {
            return _carDal.GetList(p => p.NumberOfSeats == numberOfSeats);
        }

        public Car GetByPlateNumber(string plateNumber)
        {
            return _carDal.Get(p => p.PlateNumber == plateNumber);
        }

        public List<Car> GetByType(string type)
        {
            return _carDal.GetList(p => p.Type == type);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
