using main.solwin;
using System.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace main.UnitTests
{
    public class SolwinTests
    {
        [Test]
        public void addInstance_ToList()
        {
            //Arrange
            DateTime timeChanged = new DateTime();
            timeChanged = Convert.ToDateTime("05/01/2023 8:29:18 pm");
            var instance = new Instance(0, 0, 34, timeChanged);
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestAdd.txt";

            //Act
            solwin.addInstance(0, 34, timeChanged);

            //Assert
            Assert.AreEqual(instance, solwin.instances[0]);
        }

        [Test]
        public void eraseInstance_FromList()
        {
            //Arrange
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestErase.txt";
            string text = "";

            //Act
            solwin.eraseInstance(0);

            //Assert
            Assert.AreEqual(text, File.ReadAllText(solwin.file));
        }

        [Test]
        public void readFromFile()
        {
            //Arrange
            var instance = new Instance(0, 0, 34, Convert.ToDateTime("05/01/2023 8:29:18 pm"));
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestRead.txt";

            //Act
            solwin.readFromFile();

            //Assert
            Assert.AreEqual(instance.ToString(), solwin.instances[0].ToString());
        }

        [Test]
        public void writeToFile()
        {
            //Arrange
            DateTime timeChanged = new DateTime();
            timeChanged = Convert.ToDateTime("05/01/2023 8:29:18 pm");
            var instance = new Instance(0, 0, 34, timeChanged);
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestWrite.txt";

            //Act
            solwin.writeToFile(0, 0, 34, timeChanged);

            //Assert
            Assert.AreEqual(instance.ToString() + "\n", File.ReadAllText(solwin.file));
        }

        [Test]
        public void existsById()
        {
            //Arrange
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestExists.txt";

            //Act
            bool isTrue = solwin.existsById(0);

            //Assert
            Assert.AreEqual(true, isTrue);
        }

        [Test]
        public void changePower()
        {
            //Arrange
            DateTime timeChanged = new DateTime();
            timeChanged = Convert.ToDateTime("05/01/2023 8:29:18 pm");
            var instance = new Instance(0, 0, 43, timeChanged);
            var solwin = new Solwin();
            solwin.file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_TestChange.txt";

            //Act
            solwin.instances.Add(instance);
            solwin.change(0, 43);

            //Assert
            Assert.AreEqual(instance.ToString() + "\r\n", File.ReadAllText(solwin.file));
        }
    }
}
