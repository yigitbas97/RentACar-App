using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int userId)
        {
            _userDal.Delete(new User { Id = userId });
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetById(int userId)
        {
            return _userDal.Get(p => p.Id == userId);
        }

        public User GetByUserName(string userName)
        {
            return _userDal.Get(p => p.UserName == userName);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
