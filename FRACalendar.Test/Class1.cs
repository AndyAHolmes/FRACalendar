using System;
using System.Collections.Generic;
using System.Linq;
using FRACalendar.Controllers;
using FRACalendar.Data;
using FRACalendar.Data.Repository;
using NUnit.Framework;
using Moq;



namespace FRACalendar.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestRaceListReturned()
        {
            //Arrange
            var mockedRepository = new Mock<IRaceRepository>(MockBehavior.Strict);
            var returnedRaces = new List<Race>();
            returnedRaces.Add(new Race { Id = 1, Name = "Race 1", FRAInsured = true, Price = 5, RaceClimbInFeet = 1000, RaceDistanceInMiles = 8, RaceDate = new DateTime(2019, 12, 14) });
            returnedRaces.Add(new Race { Id = 2, Name = "Race 2", FRAInsured = true, Price = 7, RaceClimbInFeet = 1200, RaceDistanceInMiles = 9, RaceDate = new DateTime(2019, 12, 15) });
            mockedRepository.Setup(r => r.AllRaces).Returns(returnedRaces);

            var raceController = new RaceController(mockedRepository.Object);


            //Act
            var resultList = raceController.Get();

            //Assert
            var parsedResult = resultList.ToList();
            Assert.AreEqual(2, parsedResult.Count);
        }
    }
}
