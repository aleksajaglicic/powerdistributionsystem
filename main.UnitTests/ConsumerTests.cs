using main.consumer;
using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace main.UnitTests
{
    public class ConsumerTests
    {
        [Test]
        public void addInstance_ChangeValue_WriteToFile()
        {
            //Arrange
            var consumer1 = new Consumer(1, "Sporetic", 66);
            var logfun = new LogicFunctions();
            List<Consumer> list = new List<Consumer>();
            list.Add(consumer1);

            //Act
            logfun.Add(consumer1);

            //Assert
            Assert.AreEqual(list, logfun.archive);
        }
    }
}
