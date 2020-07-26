using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Business.Abstract
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int customerId);
        List<Customer> GetAll();
        Customer GetById(int customerId);
        Customer GetByTC(string customerTC);
        List<Customer> GetByName(string customerName);
        List<Customer> GetBySurname(string customerSurname);
        List<Customer> GetByGender(string customerGender);
        List<Customer> GetByPhoneNumber(string customerPhoneNumber);
    }
}
