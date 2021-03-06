using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        void Delete(int id);
        Customer Read(int id);
        List<Customer> ReadAll();
    }
}
