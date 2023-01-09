using NUnit.Framework;
using System;

namespace main
{

    public class Tests
    {
        [Test]
        [TestCase(1000, 200, true)]
        [TestCase(null, null, null)]


        public void PlantKOnstruktorDobriParametri(int power, int output, bool status)
        {
            Projekat.powerplant.plant p = new Projekat.powerplant.plant(power, output, status);
            Assert.AreEqual(p.Power, power);
            Assert.AreEqual(p.Output, output);
            Assert.AreEqual(p.Status, status);

        }
        [Test]
        [TestCase(1000, 1500, true)]
        [TestCase(1000, 500, false)]
        public void PlantKOnstruktorLosiParametri(int power, int output, bool status)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Projekat.powerplant.plant p = new Projekat.powerplant.plant(power, output, status);
            });

        }




        //mock test

        plant p1;
        [SetUp]
        public void SetUp()
        {
            var moq = new Mock<plant>();
            moq.Setup(p => p.Status).Returns(false);
            p1 = moq.Object;
        }

        [Test]
        [TestCase(1000, 0)]

        public void WriteIntoFile(int power, int output)
        {

            plant p = new plant(p1);

            Assert.AreEqual(p, p1);
            Assert.AreEqual(p.Power, power);
            Assert.AreEqual(p.Output, output);
            Assert.AreEqual(p.Status, p1.Status);
        }

    }
}