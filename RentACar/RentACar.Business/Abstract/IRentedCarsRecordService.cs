using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface IRentedCarsRecordService
    {
        void Add(RentedCarsRecord rentedCarsRecord);
        void Delete(RentedCarsRecord rentedCarsRecord);
        void Update(RentedCarsRecord rentedCarsRecord);
        List<RentedCarsRecord> GetAll();
        RentedCarsRecord GetById(int rentedCarsRecordId);
        List<RentedCarsRecord> GetByDate(DateTime startDate, DateTime endDate); // start = stard end = end
        List<RentedCarsRecord> GetDateByRange(DateTime startDate, DateTime endDate);
        List<RentedCarsRecord> GetByState(string rentedCarsRecordState);
        List<RentedCarsRecord> GetByUserTC(string customerTC);
        List<RentedCarsRecord> GetByCarPlateNumber(string carPlateNumber);
    }
}
