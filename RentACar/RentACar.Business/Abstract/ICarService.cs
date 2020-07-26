using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrand(string brand);
        List<Car> GetByModel(string model);
        List<Car> GetByType(string type);
        List<Car> GetByGearType(string gearType);
        List<Car> GetByColor(string color);
        List<Car> GetByNumberOfSeats(int numberOfSeats);
        Car GetById(int carId);
        Car GetByPlateNumber(string plateNumber);
        void Add(Car car);
        void Update(Car car);
        void Delete(int carId);
    }
}
