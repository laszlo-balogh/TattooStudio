using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class TattooController : ControllerBase
    {
        private readonly ITattooLogic logic;
        private readonly ILogger<TattooController> logger;
        public TattooController(ITattooLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public List<Tattoo> Get()
        {
            logger.LogInformation($"Controller action executed on {DateTime.Now.TimeOfDay}");
            var result = logic.ReadAll().ToList();
            logger.LogInformation($"Database has {result.Count} customer.");
            return result;

        }
    }
}
