using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface ICarMaintenanceService
    {
        void Add(CarMaintenance carMaintenance);
        void Delete(int carMaintenanceId);
        void Update(CarMaintenance carMaintenance);
        List<CarMaintenance> GetAll();
        CarMaintenance GetById(int carMaintenanceId);
        CarMaintenance GetByPlateNumber(string carMaintenancePlateNumber); // unique
    }
}
