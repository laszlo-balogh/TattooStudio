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
    public class TattooController
    {
        ITattooLogic logic;
        public TattooController(ITattooLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Tattoo> Get()
        {
            return logic.ReadAll();
        }
    }
}
