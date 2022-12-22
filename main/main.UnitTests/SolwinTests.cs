using main.solwin;
using System.IO;
using NUnit.Framework;

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

            //Act
            solwin.addInstance(1, 1, 22);

            //Assert
            Assert.AreEqual(text, File.ReadAllText(solwin.file));
        }
    }
}
