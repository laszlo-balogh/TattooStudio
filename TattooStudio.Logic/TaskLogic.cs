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
        private readonly IWorkRepository workRepo;
        

        public TaskLogic(IWorkRepository workRepo)
        {
            this.workRepo = workRepo;
            
        }           
        public IEnumerable<object> WhatWantedByName()
        {           

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
