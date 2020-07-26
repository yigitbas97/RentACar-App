using RentACar.Core.DataAccess;
using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DataAccess.Abstract
{
    public interface ICarMaintenanceDal: IEntityRepository<CarMaintenance>
    {
    }
}
