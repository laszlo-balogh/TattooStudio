using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;
using TattooStudio.Repository;

namespace TattooStudio.Logic
{
    public class TaskLogic : ITaskLogic
    {
        IWorkRepository workRepo;
        ICustomerRepository customerRepo;

        public TaskLogic(IWorkRepository workRepo, ICustomerRepository customerRepo)
        {
            this.workRepo = workRepo;
            this.customerRepo = customerRepo;
        }

        public int HowManyTimes(string name,DateTime bornDate)
        {
            var v1 = from x in workRepo.ReadAll()
                     where x.Customer.Name == name && x.Customer.BornDate == bornDate
                     select new
                     {
                         Nmae = x.Customer.Name
                     };

            return v1.Count();

        }

        public IEnumerable<KeyValuePair<DateTime, List<Tattoo>>> WhatWanted(string name, DateTime bornDate)
        {
            var v1 = from x in workRepo.ReadAll()
                     where x.Customer.Name == name && x.Customer.BornDate == bornDate
                     select new KeyValuePair<DateTime, List<Tattoo>>(x.Date,x.Tattoos);                  
            return v1;
        }
    }
}
