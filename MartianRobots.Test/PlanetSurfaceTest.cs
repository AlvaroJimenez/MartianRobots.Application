using MartianRobots.Domain;
using MartianRobots.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MartianRobots.Test
{
    [TestClass]
    public class PlanetSurfaceTest
    {
        [TestMethod]
        public void GivenAPosition_WhenCallIsValidPosition_PositionIsValid()
        {
            IPlanetSurface planetsurface = new PlanetSurface(5, 3);
            Position newPosition = new Position(4, 3, Orientation.East, Instructions.Forward);
            var result = planetsurface.IsValidPosition(newPosition, out bool lost);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void GivenAPosition_WhenCallIsValidPosition_PositionInvalidAndRobotLost()
        {
            IPlanetSurface planetsurface = new PlanetSurface(2, 2);
            Position newPosition = new Position(2, 3, Orientation.East, Instructions.Forward);
            var result = planetsurface.IsValidPosition(newPosition, out bool lost);
            Assert.AreEqual(result, false);
            Assert.AreEqual(lost, true);

        }

        [TestMethod]
        public void GivenAPosition_WhenCallIsValidPosition_PositionInvalidAndRobotNotLost()
        {
            IPlanetSurface planetsurface = new PlanetSurface(2, 2);
            Position newPosition = new Position(2, 3, Orientation.East, Instructions.Forward);
            planetsurface.AddLostPoint(new Position(2, 3, Orientation.East, Instructions.Forward));
            var result = planetsurface.IsValidPosition(newPosition, out bool lost);
            Assert.AreEqual(result, false);
            Assert.AreEqual(lost, false);
        }
        [TestMethod]

        [ExpectedException(typeof(ArgumentException), "The size is bigger than 50")]
        public void GivenWrongSize_WhenCreatePlanetSurface_ReturnException()
        {
            IPlanetSurface planetsurface = new PlanetSurface(51, 50);

        }


    }
}
