using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Logic;
using TattooStudio.Models;
using TattooStudio.Endpoint.DTOs;

namespace TattooStudio.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;
        private readonly ILogger<CustomerController> logger;
        public readonly IMapper mapper;
        public CustomerController(ILogger<CustomerController> logger, ICustomerLogic customerLogic,IMapper mapper)
        {
            this.customerLogic = customerLogic;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            // a paraméterként megkapott customerben minden benne van, create at,deleteat stb, ezek nem kkelenk, ezért kimentjük a szükséges adatokat
            //egy customer-be majd ezek alapján hozzuk létre a DB-be beszúrni kívánt customert, és vissza is csak ezeket a szükséges adatokat adjuk

            Customer customerDb = null;
            try
            {
                var mappedCustomer = mapper.Map<Customer>(customer);

                customerDb = customerLogic.Create(mappedCustomer);

                if (customerDb == null)
                {
                    return StatusCode(500);
                }
                else
                {                    
                    var custDto = mapper.Map<CustomerDto>(customerDb);

                    return Ok(custDto);
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

            logger.LogInformation($"Database has {result.Count} customer.");
            return mapper.Map<List<CustomerDto>>(result);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerLogic.Delete(id);
        }

        [HttpGet("{id}")]
        public CustomerDto Read(int id)
        {
            try
            {
                Customer customer = customerLogic.Read(id);

                return mapper.Map<CustomerDto>(customer);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return null;
            }
           
        }

    }
}
