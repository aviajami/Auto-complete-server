using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auto_complete_server.Contexts;
using Auto_complete_server.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auto_complete_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICitiesContext m_CitiesContext;
        public CitiesController(ICitiesContext citiesContext)
        {
            m_CitiesContext = citiesContext;
        }

        [HttpGet]
        [Route("cities")]
        [ProducesResponseType(typeof(IEnumerable<GetCitiesResult>),200)]
        public async Task<IActionResult> Get([FromQuery(Name = "char")] string characters)
        {
            try
            {
                var result = await m_CitiesContext.GetCities(characters);
                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            //IEnumerable<City> cities = new List<City>();
        
        }
    }
}
