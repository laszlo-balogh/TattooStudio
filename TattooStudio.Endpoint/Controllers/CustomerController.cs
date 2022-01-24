using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Logic;
using TattooStudio.Models;
using TattooStudio.Models.DTOs;

namespace TattooStudio.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;
        private readonly ILogger<CustomerController> logger;
        public CustomerController(ILogger<CustomerController> logger, ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            // a paraméterként megkapott customerben minden benne van, create at,deleteat stb, ezek nem kkelenk, ezért kimentjük a szükséges adatokat
            //egy customer-be majd ezek alapján hozzuk létre a DB-be beszúrni kívánt customert, és vissza is csak ezeket a szükséges adatokat adjuk

            Customer customerDb = null;
            try
            {
                customerDb = new Customer
                {
                    CustomerID = customer.CustomerID,
                    BornDate = customer.BornDate,
                    Email = customer.Email,
                    Name = customer.Name,
                    IsDeleted=customer.IsDeleted
                    
                };

                customerDb = customerLogic.Create(customerDb);

                if (customerDb == null)
                {
                    return StatusCode(500);
                }
                else
                {
                    var customerDto = new CustomerDto()
                    {
                        CustomerID = customerDb.CustomerID,
                        BornDate = customerDb.BornDate,
                        Email = customerDb.Email,
                        Name = customerDb.Name,
                        IsDeleted=customerDb.IsDeleted
                    };

                    return Ok(customerDto);
                }

            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return StatusCode(400, ex.Message);

            }

        }

        [HttpGet]
        public List<CustomerDto> Get()
        {
            logger.LogInformation($"Controller action executed on {DateTime.UtcNow.TimeOfDay}");
            var result = customerLogic.ReadAll();
            List<CustomerDto> customerDtoList = new List<CustomerDto>();

            foreach (var item in result)
            {
                customerDtoList.Add(new CustomerDto
                {
                    CustomerID = item.CustomerID,
                    Name = item.Name,
                    BornDate = item.BornDate,
                    Email = item.Email,
                    IsDeleted=item.IsDeleted

                });
            }

            logger.LogInformation($"Database has {result.Count} customer.");
            return customerDtoList;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerLogic.Delete(id);
        }

        [HttpGet("{id}")]
        public CustomerDto Read(int id)
        {
            Customer customer = customerLogic.Read(id);

            CustomerDto cDto = new CustomerDto
            {
                CustomerID=customer.CustomerID,
                Name=customer.Name,
                BornDate=customer.BornDate,
                Email=customer.Email,
                IsDeleted=customer.IsDeleted
            };

            return cDto;
        }

    }
}
