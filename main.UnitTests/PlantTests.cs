using Moq;
using NUnit.Framework;
using powerdistributionsystem.powerplant;
using System;

namespace powerdistributionsystem.UnitTests
{

    public class PlantTests
    {
        [Test]
        public void turnOn_Plant_PowerFullfiled()
        {
            //Arrange
            int generatedPower = 34;
            int usedPower = 24;
            var plant = new Plant();

            //Act
            plant.turnOnPlant(generatedPower, usedPower);

            //Assert
            Assert.AreEqual(false, plant.Status);
        }

        [Test]
        public void turnOn_Plant_PowerUnfullfiled()
        {
            //Arrange
            int generatedPower = 34;
            int usedPower = 74;
            var plant = new Plant();

            //Act
            plant.turnOnPlant(generatedPower, usedPower);

            //Assert
            Assert.AreEqual(true, plant.Status);
        }

        [Test]
        public void turnOn_Plant_PowerExceeds()
        {
            //Arrange
            int generatedPower = 34;
            int usedPower = 1000;
            var plant = new Plant();

            //Act
            plant.turnOnPlant(generatedPower, usedPower);

            //Assert
            Assert.AreEqual(false, plant.Status);
        }

        //Plant p1;
        //[SetUp]
        //public void SetUp()
        //{
        //    var moq = new Mock<Plant>();
        //    moq.Setup(p => p.Status).Returns(false);
        //    p1 = moq.Object;
        //}

        //[Test]
        //[TestCase(0)]

        //public void WriteIntoFile(int output)
        //{
        //    Plant p = new Plant(p1);

        //    Assert.AreEqual(p, p1);
        //    Assert.AreEqual(p.Output, output);
        //    Assert.AreEqual(p.Status, p1.Status);
        //}
    }
}