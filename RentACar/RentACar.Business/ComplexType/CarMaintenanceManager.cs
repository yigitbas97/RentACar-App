using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.ComplexType
{
    public class CarMaintenanceManager : ICarMaintenanceService
    {
        private ICarMaintenanceDal _carMaintenanceDal;
        public CarMaintenanceManager(ICarMaintenanceDal carMaintenanceDal)
        {
            _carMaintenanceDal = carMaintenanceDal;
        }
        public void Add(CarMaintenance carMaintenance)
        {
            _carMaintenanceDal.Add(carMaintenance);
        }

        public void Delete(int carMaintenanceId)
        {
            _carMaintenanceDal.Delete(new CarMaintenance { Id = carMaintenanceId });
        }

        public List<CarMaintenance> GetAll()
        {
            return _carMaintenanceDal.GetList();
        }

        public CarMaintenance GetById(int carMaintenanceId)
        {
            return _carMaintenanceDal.Get(p => p.Id == carMaintenanceId);
        }

        public CarMaintenance GetByPlateNumber(string carMaintenancePlateNumber)
        {
            return _carMaintenanceDal.Get(p => p.PlateNumber == carMaintenancePlateNumber);
        }

        public void Update(CarMaintenance carMaintenance)
        {
            _carMaintenanceDal.Update(carMaintenance);
        }
    }
}
