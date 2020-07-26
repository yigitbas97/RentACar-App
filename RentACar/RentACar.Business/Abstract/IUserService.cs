using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
        List<User> GetAll();
        User GetById(int userId);
        User GetByUserName(string userName); // unique
    }
}
