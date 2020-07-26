using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(int customerId)
        {
            _customerDal.Delete(new Customer { Id = customerId });
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetList();
        }

        public List<Customer> GetByGender(string customerGender)
        {
            return _customerDal.GetList(p => p.Gender == customerGender);
        }

        public Customer GetById(int customerId)
        {
            return _customerDal.Get(p => p.Id == customerId);
        }

        public List<Customer> GetByName(string customerName)
        {
            return _customerDal.GetList(p => p.Name == customerName);
        }

        public List<Customer> GetByPhoneNumber(string customerPhoneNumber)
        {
            return _customerDal.GetList(p=>p.PhoneNumber == customerPhoneNumber);
        }

        public List<Customer> GetBySurname(string customerSurname)
        {
            return _customerDal.GetList(p => p.Surname == customerSurname);
        }

        public Customer GetByTC(string customerTC)
        {
            return _customerDal.Get(p => p.TC == customerTC);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
