using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FRACalendar.Data.Repository;
using FRACalendar.ServiceContract.Race;

namespace FRACalendar.Controllers
{
    [Route("api/race")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private IRaceRepository _raceRepository;
        //public RaceController()
        //{
            
        //}
        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        // GET: api/Race
        [HttpGet("list")]
        public IEnumerable<ListItem> Get()
        {
            //return new List<ListItem>() { new ListItem { Id = 1, Name = "Race 1" } };
            return _raceRepository.AllRaces.Select(r=> new ListItem { Id = r.Id, Name = r.Name });
        }

        // GET: api/Race/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Race
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
