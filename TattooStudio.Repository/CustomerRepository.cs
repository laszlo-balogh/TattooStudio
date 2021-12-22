using System;
using System.Linq;
using TattooStudio.Data;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        TattooStudioDbContext db;
        public CustomerRepository(TattooStudioDbContext db)
        {
            this.db = db;
        }
        public void Create(Customer customer)
        {
            db.Add(customer);
            db.SaveChanges();
        }       
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Customer Read(int id)
        {
            return db.Customers.FirstOrDefault(t => t.CustomerID == id);
        }

        public IQueryable<Customer> ReadAll()
        {
            return db.Customers;
        }

    }
}
