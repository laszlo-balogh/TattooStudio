using System;
using System.Collections.Generic;
using TattooStudio.Models;

namespace TattooStudio.Logic
{
    public interface ICustomerLogic
    {
        Customer Create(Customer customer);
        List<Customer> ReadAll();

        void Delete(int id);
        Customer Read(int id);
    }
}
