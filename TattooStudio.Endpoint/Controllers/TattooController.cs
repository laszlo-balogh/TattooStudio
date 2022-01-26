using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooStudio.Endpoint.DTOs;
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
        public readonly IMapper mapper;
        public TattooController(ITattooLogic logic,ILogger<TattooController> logger, IMapper mapper)
        {
            this.logic = logic;
            this.logger = logger;
            this.mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post([FromBody] TattooDto tattoo)
        {
            // a paraméterként megkapott customerben minden benne van, create at,deleteat stb, ezek nem kkelenk, ezért kimentjük a szükséges adatokat
            //egy customer-be majd ezek alapján hozzuk létre a DB-be beszúrni kívánt customert, és vissza is csak ezeket a szükséges adatokat adjuk

            Tattoo tattooodb = null;
            try
            {
                var mappedTattoo = mapper.Map<Tattoo>(tattoo);

                tattooodb = logic.Create(mappedTattoo);

                if (tattooodb == null)
                {
                    return StatusCode(500);
                }
                else
                {
                    var tattDto = mapper.Map<TattooDto>(tattooodb);

                    return Ok(tattDto);
                }

            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return StatusCode(400, ex.Message);

            }

        }

        [HttpGet]
        public List<TattooDto> Get()
        {
            logger.LogInformation($"Controller action executed on {DateTime.Now.TimeOfDay}");
            var result = logic.ReadAll();

            logger.LogInformation($"Database has {result.Count} customer.");
            return mapper.Map<List<TattooDto>>(result);

        }
        [HttpGet("{id}")]
        public TattooDto Read(int id)
        {
            Tattoo tattoo = logic.Read(id);

            return mapper.Map<TattooDto>(tattoo);
        }
    }
}
