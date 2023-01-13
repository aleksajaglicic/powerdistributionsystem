using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using powerdistributionsystem.solwin;
using powerdistributionsystem.consumer;

namespace powerdistributionsystem.distributioncenter
{
    /// <summary>
    /// This class performs calculation methods for the power plant
    /// </summary>
    public class Center
    {
        /// <summary>
        /// Instance of SolarWind class
        /// </summary>
        public Solwin sw = new Solwin();
        /// <summary>
        /// Instance of LogicFunctions class
        /// </summary>
        public LogicFunctions lf = new LogicFunctions();
        /// <summary>
        /// File path for sw instances
        /// </summary>
        public string fileInstance = Environment.CurrentDirectory + "/files/SolarWindInstances.txt";
        /// <summary>
        /// File path for socket instances
        /// </summary>
        public string fileSockets = Environment.CurrentDirectory + "/files/SocketInstances.txt";

        /// <summary>
        /// Reads panel/gen instances from file
        /// </summary>
        public void readInstancesFromFile()
        {
            StreamReader sr = null;
            string lines;
            int idR;
            int idSW;
            int powerR;
            DateTime timeChanged;

            sw.instances.Clear();

            try
            {
                sr = new StreamReader(fileInstance);

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] lineParts = lines.Split('|');
                    idR = Int32.Parse(lineParts[0]);
                    powerR = Int32.Parse(lineParts[1]);
                    idSW = Int32.Parse(lineParts[2]);
                    timeChanged = Convert.ToDateTime(lineParts[3]);

                    Instance instanceR = new Instance(idR, idSW, powerR, timeChanged);
                    sw.instances.Add(instanceR);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// Reads socket instances from file
        /// </summary>
        public void readSocketsFromFile()
        {
            StreamReader sr = null;
            string lines = "";
            string name = "";
            int id = 0;
            int kwh = 0;

            try
            {
                sr = new StreamReader(fileSockets);

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] lineParts = lines.Split('|');
                    try
                    {
                        Int32.TryParse(lineParts[0], out id);
                        name = lineParts[1];
                        Int32.TryParse(lineParts[2], out kwh);
                    }
                    catch(Exception)
                    { }
                    lf.archive.Add(new Consumer(id, name, kwh));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// Method for calculating power generated from panel/gen instances
        /// </summary>
        /// <returns>int of calculated power</returns>
        public int powerCalculator()
        {
            int powerNum = 0;
            readInstancesFromFile();

            if (sw.instances.Count == 0)
            {
                Console.WriteLine("Couldn't calculate. List is empty...");
                return -1;
            }
            else
            {
                for (int i = 0; i < sw.instances.Count; i++)
                {
                    powerNum += sw.instances[i].Power;
                }
            }

            return powerNum / sw.instances.Count;
        }

        /// <summary>
        /// Method for calculating power generated from socket instances
        /// </summary>
        /// <returns>int of calculated power</returns>
        public int socketPowerUsage()
        {
            int powerNum = 0;
            readSocketsFromFile();

            if (lf.archive.Count == 0)
            {
                Console.WriteLine("Couldn't calculate. List is empty...");
                return -1;
            }
            else
            {
                for (int i = 0; i < lf.archive.Count; i++)
                {
                    powerNum += lf.archive[i].KWH;
                }
            }

            return powerNum / lf.archive.Count; ;
        }
    }
}
