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
        public Race Get(int id)
        {
            return _raceRepository.AllRaces.Select(r=>new Race { Id = r.Id, Name = r.Name, Price = r.Price, RaceDate = r.RaceDate }).FirstOrDefault(r=>r.Id == id);
        }

        // POST: api/Race
        [HttpPost]
        public IActionResult Post([FromBody] Race value)
        {
            
            _raceRepository.Add(new Data.Race() { Name = value.Name, Price = value.Price, RaceDate = value.RaceDate });
            return Ok();
        }

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Race value)
        {
            _raceRepository.Update(new Data.Race() {Id=id, Name = value.Name, Price = value.Price, RaceDate = value.RaceDate });
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _raceRepository.Delete(id);
            return Ok();
        }
    }
}
