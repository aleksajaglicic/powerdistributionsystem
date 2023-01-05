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
        public void addInstance_ChangeValue_WriteToFile()
        {
            //Arrange
            var solwin = new Solwin();
            string text = "0	|	22	|	1	|	22/12/2022 7:31:20 pm\n";
            string file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_Test.txt";

            //Act
            solwin.addInstanceTest(1, 22, file);

            //Assert
            Assert.AreEqual(text, File.ReadAllText(file));
        }

        [Test]
        public void readInstanceEraseInstance_WriteToFile()
        {
            //Arrange
            var solwin = new Solwin();
            int id = 0;
            string text = "";
            string file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_Test.txt";

            //Act
            solwin.eraseInstanceTest(id, file);

            //Assert
            Assert.AreEqual(text, File.ReadAllText(file));
        }

        [Test]
        public void readFromFileTest()
        {
            //Arrange
            var solwin = new Solwin();
            string file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_Test.txt";
            List<Instance> instances = new List<Instance>();
            Instance instance = new Instance(0, 1, 22, Convert.ToDateTime("22/12/2022 7:31:20 pm"));

            //Act
            solwin.readFromFileTest(instances, file);

            //Assert
            Assert.AreEqual(instance, instances[0]);
        }

        [Test]
        public void writeToFileTest()
        {
            //Arrange
            var solwin = new Solwin();
            string file = Environment.CurrentDirectory + "/TestFile/SolarWindInstances_Test.txt";
            Instance instance = new Instance(0, 0, 22, Convert.ToDateTime("22/12/2022 7:31:20 pm"));

            //Act
            solwin.writeToFileTest(0, 0, 22, Convert.ToDateTime("22/12/2022 7:31:20 pm"), file);

            //Assert
            Assert.AreEqual(instance.ToString(), File.ReadAllText(file));
        }
    }
}
