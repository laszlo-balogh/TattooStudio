using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Logic;
using TattooStudio.Models;

namespace TattooStudio.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskLogic logic;

        public TaskController(ITaskLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public int HowManyTimes(string name, DateTime bornDate)
        {
            return logic.HowManyTimes(name, bornDate);
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<DateTime, List<Tattoo>>> WhatWanted(string name, DateTime bornDate)
        {
            return logic.WhatWanted(name, bornDate);
        }
    }
}
