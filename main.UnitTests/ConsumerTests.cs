using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using powerdistributionsystem.consumer;
using Moq;

namespace powerdistributionsystem.UnitTests
{
    public class ConsumerTests
    {
        [Test]
        public void addInstance_ToList()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporet", 55);
            var logfun = new LogicFunctions();
            List<Consumer> list = new List<Consumer>();
            list.Add(consumer1);

            //Act
            logfun.Add(consumer1);

            //Assert
            Assert.AreEqual(list, logfun.archive);
        }

        [Test]
        public void removeInstance_FromList()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporet", 55);
            var logfun = new LogicFunctions();
            List<Consumer> list = new List<Consumer>();
            logfun.archive.Add(consumer1);
            //Act
            logfun.Remove(1);

            //Assert
            Assert.AreEqual(list, logfun.archive);
        }

        [Test]
        public void findInstance_FromList()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporet", 55);
            var logfun = new LogicFunctions();
            logfun.archive.Add(consumer1);
            
            //Act
            Consumer c=logfun.Find(1);

            //Assert
            Assert.AreEqual(c,consumer1);
        }

        [Test]
        public void readFromFileTest()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporet", 55);
            var logfun = new LogicFunctions();
            List<Consumer> list = new List<Consumer>();
            list.Add(consumer1);
            string file = Environment.CurrentDirectory + "/TestFile/Consumer_Test.txt";
            
            //Act
            logfun.ReadFromFile(file);
            
            //Assert
            Assert.AreEqual(list.ToString(), logfun.archive.ToString());
        }

        [Test]
        public void writeToFileTest()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporet", 55);
            var logfun = new LogicFunctions();
            List<Consumer> list = new List<Consumer>();
            list.Add(consumer1);
            string file = Environment.CurrentDirectory + "/TestFile/Consumer_Write_Test.txt";

            //Act
            logfun.archive.Add(consumer1);
            logfun.WriteToFile(file);

            //Assert
            Assert.AreEqual(consumer1.ToString()+"\n\r\n", File.ReadAllText(file));
        }

        Mock<LogicFunctions> mockLogicFunctionService;

        LogicFunctions systemUnderTest;

        [TestCase(14, "Computer", 40)]

        public void addInstance_ToList(int id, string naziv, int kwh)
        {
            mockLogicFunctionService = new Mock<LogicFunctions>();
            Consumer c1 = new Consumer(id, naziv, kwh);
            mockLogicFunctionService = new Mock<LogicFunctions>(MockBehavior.Strict);


            systemUnderTest = new LogicFunctions();
            var result = systemUnderTest.Add(c1);

            Assert.AreEqual(true, result);

            mockLogicFunctionService.VerifyAll();
        }

        [TestCase(14, "Computer", 40)]

        public void removeInstance_FromList(int id, string naziv, int kwh)
        {
            mockLogicFunctionService = new Mock<LogicFunctions>();
            Consumer c1 = new Consumer(id, naziv, kwh);
            mockLogicFunctionService = new Mock<LogicFunctions>(MockBehavior.Strict);


            systemUnderTest = new LogicFunctions();
            var result = systemUnderTest.Remove(c1.Id);

            Assert.AreEqual(false, result);

            mockLogicFunctionService.VerifyAll();
        }
    }
}
