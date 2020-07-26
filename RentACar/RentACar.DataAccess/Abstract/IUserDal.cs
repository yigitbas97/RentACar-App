using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
