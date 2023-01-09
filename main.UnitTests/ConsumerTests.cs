using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using main.consumer;

namespace main.UnitTests
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

    }
}
