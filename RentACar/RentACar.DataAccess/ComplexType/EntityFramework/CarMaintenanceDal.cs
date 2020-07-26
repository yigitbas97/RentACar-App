using RentACar.Core.DataAccess.EntityFramework;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete;
using RentACar.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RentACar.DataAccess.ComplexType.EntityFramework
{
    public class CarMaintenanceDal : EntityRepositoryBase<CarMaintenance, RentACarContext>, ICarMaintenanceDal
    {   
    }
}
