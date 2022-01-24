using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;
using TattooStudio.Repository;

namespace TattooStudio.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepository customerRepo;
        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer Create(Customer customer)
        {                               
            return customerRepo.Create(customer);
        }

        public void Delete(int id)
        {
            Customer customer = Read(id);

            if (customer!=null)          
            {
                if (!customer.IsDeleted)
                {
                    customerRepo.Delete(id);
                }
                
            }
        }

        public Customer Read(int id)
        {
            if (id<1)
            {
                throw new ArgumentException("id cannot be lower than 1");
            }
            else
            {
                return customerRepo.Read(id);
            }
        }

        public List<Customer> ReadAll()
        {
            return this.customerRepo.ReadAll();
        }
    }
}
