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
        ICustomerRepository customerRepo;
        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public void Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            else if (customer.Name == null || customer.Name.Length == 0)
            {
                throw new ArgumentException("Name cannot be null");
            }
            else if (customer.BornDate == default)
            {
                throw new ArgumentException("Born date cannot be empty");
            }            
            else if (customer.Email == null)
            {
                throw new ArgumentException("Email cannot be null");
            }
            else if (customer.Email.Contains('@'))
            {
                string[] array = customer.Email.Split('@');
                if (array.Length > 2)
                {
                    throw new ArgumentException("Wrong email format");
                }
                else if (!array[1].Contains('.'))
                {
                    throw new ArgumentException("Wrong email format");
                }
            }
            else if (!customer.Email.Contains('@'))
            {
                throw new ArgumentException("Wrong email format");
            }
            else
            {
                this.customerRepo.Create(customer);
            }
        }

        public IEnumerable<Customer> ReadAll()
        {
            return this.customerRepo.ReadAll();
        }
    }
}
