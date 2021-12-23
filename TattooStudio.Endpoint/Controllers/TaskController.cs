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
    //[Route("[controller]/{name}&{date}/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskLogic logic;

        public TaskController(ITaskLogic logic)
        {
            this.logic = logic;
        }
             

        [HttpGet]
        public IEnumerable<object> WhatWantedByName()
        {
            return logic.WhatWantedByName();
        }
    }
}
