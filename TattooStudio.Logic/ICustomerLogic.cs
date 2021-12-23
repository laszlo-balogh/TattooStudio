using System;
using System.Collections.Generic;
using TattooStudio.Models;

namespace TattooStudio.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        IEnumerable<Customer> ReadAll();
    }
}
