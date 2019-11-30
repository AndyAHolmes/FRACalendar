using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FRACalendar.Data.Repository
{
    public interface IRaceRepository
    {
        IEnumerable<Race> AllRaces { get; }
        int Add(Race newItem);
        void Update(Race updatedItem);
        void Delete(int id);
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

        public int Add(Race newItem)
        {
            _context.Add(newItem);
            _context.SaveChanges();
            return newItem.Id;

        }
        public void Update(Race updatedItem)
        {
            var itemToUpdate =_context.Races.FirstOrDefault(r => r.Id == updatedItem.Id);
            if (itemToUpdate == null) throw new Exception("Race not found");
            itemToUpdate.Name = updatedItem.Name;
            itemToUpdate.Price = updatedItem.Price;
            itemToUpdate.RaceDate = updatedItem.RaceDate;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemToRemove = _context.Races.FirstOrDefault(r => r.Id == id);
            if (itemToRemove == null) return;
            _context.Races.Remove(itemToRemove);
            _context.SaveChanges();
        }
    }
}
