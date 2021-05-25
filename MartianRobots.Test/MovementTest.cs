using MartianRobots.Domain;
using MartianRobots.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace MartianRobots.Test
{
    [TestClass]

    public class MovementTest
    {

        //[AssemblyInitialize]
        //public static void AssemblyInitialize(TestContext context)
        //{

        //}

        [TestMethod]
        public void GivenAMovement_WhenCallLeftMovement_MovementIsValid()
        {
            
            var mockBar = new Mock<IPlanetSurface>();
            bool lost = false;
            mockBar.Setup(mock => mock.IsValidPosition(It.IsAny<Position>(), out lost)).Returns(true);
            Robot robot = new Robot
            {
                Position = new Position(2, 3, Orientation.North, Instructions.Left)
            };

            IMovement movement = new Movement(Instructions.Forward, robot, mockBar.Object);
            var robotlost = movement.ExecuteMovement();
            Assert.AreEqual(robotlost, false);
        }
        [TestMethod]
        public void GivenAMovement_WhenCallRightMovement_MovementIsValid()
        {
            var mockBar = new Mock<IPlanetSurface>();
            bool lost = false;
            mockBar.Setup(mock => mock.IsValidPosition(It.IsAny<Position>(), out lost)).Returns(true);
            Robot robot = new Robot
            {
                Position = new Position(2, 3, Orientation.North, Instructions.Right)
            };

            IMovement movement = new Movement(Instructions.Forward, robot, mockBar.Object);
            var robotlost = movement.ExecuteMovement();
            Assert.AreEqual(robotlost, false);
        }
        [TestMethod]
        public void GivenAMovement_WhenCallForwardMovement_MovementIsValid()
        {
            var mockBar = new Mock<IPlanetSurface>();
            bool lost = false;
            mockBar.Setup(mock => mock.IsValidPosition(It.IsAny<Position>(), out lost)).Returns(true);
            Robot robot = new Robot
            {
                Position = new Position(2, 3, Orientation.North, Instructions.Forward)
            };

            IMovement movement = new Movement(Instructions.Forward, robot, mockBar.Object);
            var robotlost = movement.ExecuteMovement();
            Assert.AreEqual(robotlost, false);
        }



        [TestMethod]
        public void GivenAMovement_WhenCallAnyMovement_MovementIsNotValidAndRobotIsLost()
        {
            var mockBar = new Mock<IPlanetSurface>();
            bool lost = true;
            mockBar.Setup(mock => mock.IsValidPosition(It.IsAny<Position>(), out lost)).Returns(false);
            Robot robot = new Robot
            {
                Position = new Position(2, 3, Orientation.North, Instructions.Left)
            };

            IMovement movement = new Movement(Instructions.Forward, robot, mockBar.Object);
            var robotlost = movement.ExecuteMovement();
            Assert.AreEqual(robotlost, true);
        }

        [TestMethod]
        public void GivenAMovement_WhenCallAnyMovement_MovementIsNotValidAndRobotIsNotLost()
        {
            
               var mockBar = new Mock<IPlanetSurface>();
            bool lost = false;
            mockBar.Setup(mock => mock.IsValidPosition(It.IsAny<Position>(), out lost)).Returns(true);
            Robot robot = new Robot
            {
                Position = new Position(2, 3, Orientation.South, Instructions.Forward)
            };
            Position newPosition = new Position(2, 2, Orientation.South, Instructions.Forward);
            IMovement movement = new Movement(Instructions.Forward, robot, mockBar.Object);
            var robotlost = movement.ExecuteMovement();
            Assert.AreEqual(robot.Position.Y, newPosition.Y);
            Assert.AreEqual(robot.Position.X, newPosition.X);
            Assert.AreEqual(robot.Position.Orientation, newPosition.Orientation);
            Assert.AreEqual(robotlost, false);
        }

    }
}
