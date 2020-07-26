using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.ComplexType;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.ComplexType
{
    public class RentedCarsRecordManager : IRentedCarsRecordService
    {
        private IRentedCarsRecordDal _rentedCarsRecordDal;
        public RentedCarsRecordManager(IRentedCarsRecordDal rentedCarsRecordService)
        {
            _rentedCarsRecordDal = rentedCarsRecordService;
        }
        public void Add(RentedCarsRecord rentedCarsRecord)
        {
            _rentedCarsRecordDal.Add(rentedCarsRecord);
        }

        public void Delete(RentedCarsRecord rentedCarsRecord)
        {
            _rentedCarsRecordDal.Delete(rentedCarsRecord);
        }

        public List<RentedCarsRecord> GetAll()
        {
            return _rentedCarsRecordDal.GetList();
        }

        public RentedCarsRecord GetById(int rentedCarsRecordId)
        {
            return _rentedCarsRecordDal.Get(p => p.Id == rentedCarsRecordId);
        }

        public List<RentedCarsRecord> GetByDate(DateTime startDate, DateTime endDate)
        {
            return _rentedCarsRecordDal.GetList(p => p.StartDate == startDate && p.EndDate == endDate);
        }

        public void Update(RentedCarsRecord rentedCarsRecord)
        {
            _rentedCarsRecordDal.Update(rentedCarsRecord);
        }

        public List<RentedCarsRecord> GetDateByRange(DateTime startDate, DateTime endDate)
        {
            return _rentedCarsRecordDal.GetList
                (p => p.StartDate > endDate || p.EndDate < startDate);
        }

        public List<RentedCarsRecord> GetByState(string rentedCarsRecordState)
        {
            return _rentedCarsRecordDal.GetList(p => p.State == rentedCarsRecordState);
        }

        public List<RentedCarsRecord> GetByUserTC(string customerTC)
        {
            return _rentedCarsRecordDal.GetList(p => p.TC == customerTC);
        }

        public List<RentedCarsRecord> GetByCarPlateNumber(string carPlateNumber)
        {
            return _rentedCarsRecordDal.GetList(p => p.PlateNumber == carPlateNumber);
        }
    }
}
