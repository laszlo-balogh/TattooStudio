using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Logic;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController
    {
        ICustomerLogic customerLogic;
        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            customerLogic.Create(customer);
        }

    }
}
