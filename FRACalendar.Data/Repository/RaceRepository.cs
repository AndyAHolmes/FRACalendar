using System;
using System.Collections.Generic;
using System.Text;

namespace FRACalendar.Data.Repository
{
    public interface IRaceRepository
    {
        IEnumerable<Race> AllRaces { get;  }
    }
    public class RaceRepository : IRaceRepository
    {
        private FRACalendarContext _context;
        public RaceRepository(FRACalendarContext context) {
            _context = context;
        }

        public IEnumerable<Race> AllRaces
        { 
            get => _context.Races;
        }
    }
}
