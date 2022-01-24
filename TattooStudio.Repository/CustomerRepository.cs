using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TattooStudio.Data;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TattooStudioDbContext db;
        private readonly ILogger<CustomerRepository> logger;
        public CustomerRepository(ILogger<CustomerRepository> logger, TattooStudioDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }
        public Customer Create(Customer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.UtcNow;

                db.Add(customer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message + $" at {DateTime.UtcNow.TimeOfDay}", ex.Message);
                return null;
            }
            

            return customer;
        }       
        public void Delete(int id)
        {
            try
            {
                Customer customer = Read(id);
                customer.IsDeleted = true;
                customer.DeletedAt = DateTime.UtcNow;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                logger.LogError(ex.GetType().Name + " - " + ex.Message + $" at {DateTime.UtcNow.TimeOfDay}", ex.Message);
            }
           
        }

        public Customer Read(int id)
        {
            try
            {
                return db.Customers.FirstOrDefault(t => t.CustomerID == id);
            }
            catch (Exception ex)
            {

                logger.LogError(ex.GetType().Name + " - " + ex.Message + $" at {DateTime.UtcNow.TimeOfDay}" , ex.Message);
                return null; // a tryban is dobhatok nullt ha nincs ilyen idex, ez nem a legjobb
            }
            
        }

        public List<Customer> ReadAll()
        {
            try
            {
                var customers = from customer in db.Customers
                                           where !customer.IsDeleted 
                                           select new Customer
                                           {
                                               
                                               CreatedAt=customer.CreatedAt,
                                               DeletedAt=customer.DeletedAt,
                                               IsDeleted = customer.IsDeleted,
                                               CustomerID =customer.CustomerID,
                                               BornDate = customer.BornDate,
                                               Email =customer.Email,
                                               Name=customer.Name,
                                               Works=customer.Works                                               
                                           };                                
                return customers.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message + $" at {DateTime.UtcNow.TimeOfDay}", ex.Message);
                return new List<Customer>();                
            }
            
        }

    }
}
