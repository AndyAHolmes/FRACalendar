using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FRACalendar.Data
{
    public class Race
    {
        public int Id { get; set; }
        
        [StringLength(200)]
        public string Name { get; set; }
        [Range(0,500)]
        public decimal RaceDistanceInMiles { get; set;}
        [Range(0, 999999)]
        public decimal RaceClimbInFeet { get; set; }
        public RaceContact PrimaryRaceContact { get; set; }
        public DateTime RaceDate { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public bool FRAInsured { get; set; }
    }

    public class RaceContact { 
        public int Id { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [RegularExpression(@"0\d[8,10]")]
        public string ContactPhoneNumber { get; set; }
        [StringLength(300)]
        [RegularExpression(@"[\w\.]*@[\w\.]*")]
        public string ContactEmailAddress { get; set; }
        [StringLength(200)]
        public string AddressLine1 { get; set;}
        [StringLength(200)]
        public string AddressLine2 { get; set;}
        [StringLength(200)]
        public string AddressLine3 { get; set; }
        [StringLength(100)]
        public string Town { get; set; }
        [StringLength(100)]
        public string County { get; set; }
        [StringLength(10)]
        public string Postcode { get; set; }
        public List<Race> Races { get; set; }
    }
}
