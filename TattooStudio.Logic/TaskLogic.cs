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
        public IEnumerable<object> WhatWantedByName()
        {


            //var v1 = from x in workRepo.ReadAll()
            //         where x.Customer.Name ==name/* "Nagy Ákos"*/ && x.Customer.BornDate == bornDate/*new DateTime(1999, 1, 14)*/
            //         select new KeyValuePair<DateTime, List<ReadyTattoo>>(x.Date,x.Tattoos);

            var v1 = from x in workRepo.ReadAll()
                     select new
                     {
                         Name = x.Customer.Name,
                         Date = x.Date,
                         Tattoos = x.Tattoos
                     };
            var w1 = v1.AsEnumerable().GroupBy(x => x.Name);
            return w1;
        }
    }
}
