using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace powerdistributionsystem.solwin
{
    /// <summary>
    /// This class performs panel/generator methods
    /// </summary>
    public class Solwin
    {
        /// <summary>
        /// Instances list
        /// </summary>
        public List<Instance> instances;
        /// <summary>
        /// Random value object
        /// </summary>
        public System.Random random = new System.Random();
        /// <summary>
        /// Date time object
        /// </summary>
        public DateTime timestamp = new DateTime();
        /// <summary>
        /// Instance list file directory
        /// </summary>
        public string file = Environment.CurrentDirectory + "/files/SolarWindInstances.txt";

        /// <summary>
        /// Empty constructor class
        /// </summary>
        public Solwin()
        {
            instances = new List<Instance>();
        }


        /// <summary>
        /// Reads instances from file and adds them to the instance list
        /// </summary>
        public void readFromFile()
        {
            StreamReader sr = null;
            string lines;
            int idR;
            int idSW;
            int powerR;
            DateTime timeChanged;

            instances.Clear();

            try
            {
                sr = new StreamReader(file);

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] lineParts = lines.Split('|');
                    idR = Int32.Parse(lineParts[0]);
                    powerR = Int32.Parse(lineParts[1]);
                    idSW = Int32.Parse(lineParts[2]);
                    timeChanged = Convert.ToDateTime(lineParts[3]);

                    Instance instanceR = new Instance(idR, idSW, powerR, timeChanged);
                    instances.Add(instanceR);
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
        /// Writes instance to file
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <param name="choice">Power generation method ID</param>
        /// <param name="power">Power generated</param>
        /// <param name="timeChanged">Changed power date</param>
        public void writeToFile(int id = 0, int choice = 0, int power = 0, DateTime ? timeChanged = null)
        {
            DateTime timeChangedT = (DateTime)timeChanged;
            Instance instance = new Instance(id, choice, power, timeChangedT);

            StreamWriter sw = null;
            string text = "";
            text += instance.ToString();
            text += "\n";

            try
            {
                sw = new StreamWriter(file, true);
                sw.Write(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                try
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Adds instance and writes to file
        /// </summary>
        /// <param name="c">Power generation method ID</param>
        /// <param name="cP">Power generated</param>
        /// <param name="timeChanged">Changed power date</param>
        public void addInstance(int c = 0, int cP = 0, DateTime ? timeChanged = null)
        {
            readFromFile();
            int id = instances.Count;
            writeToFile(id, c, cP, timeChanged);
        }

        /// <summary>
        /// Erases instance from list and instance file
        /// </summary>
        /// <param name="eraseId">Instance ID</param>
        public void eraseInstance(int eraseId = 0)
        {
            instances.Clear();
            readFromFile();

            for (int i = 0; i < instances.Count; i++)
            {
                if (eraseId == instances[i].ID)
                {
                    instances.RemoveAt(i);

                    StreamWriter sw = null;
                    string text = "";

                    for (int j = 0; j < instances.Count; j++)
                    {
                        text += instances[j].ToString();
                        text += "\n";
                    }

                    File.Create(file).Close();

                    try
                    {
                        sw = new StreamWriter(file);
                        sw.Write(text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    finally
                    {
                        try
                        {
                            sw.Close();
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        /// <summary>
        /// Presents a table of instances
        /// </summary>
        public void viewList()
        {
            instances.Clear();
            var table = new ConsoleTable("Id:", "Power: ", "Type", "TimeStamp");
            readFromFile();

            ConsoleTable.From<Instance>(instances).Write();
        }

        /// <summary>
        /// Method for determining whether an instance exists inside the list
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <returns></returns>
        public bool existsById(int id = 0)
        {
            readFromFile();

            for (int i = 0; i < instances.Count; i++)
            {
                if (id == instances[i].ID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes power generation of an instance
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <param name="power">New power generation value</param>
        public void change(int id = 0, int power = 0)
        {
            for (int i = 0; i < instances.Count; i++)
            {
                if (id == instances[i].ID)
                {
                    instances[i].Power = power;
                    instances[i].TimeChanged = DateTime.Now;
                }

                string text = "";
                StreamWriter sw = null;

                for (int j = 0; j < instances.Count; j++)
                {
                    text += instances[j].ToString();
                    if (j != instances.Count - 1)
                    {
                        text += "\n";
                    }
                }

                try
                {
                    File.WriteAllText(file, string.Empty);
                    sw = new StreamWriter(file);
                    sw.WriteLine(text);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    try
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    catch (Exception) { }
                }
            }
        }

        /// <summary>
        /// Equals method for Solwin class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Solwin solwin &&
                   EqualityComparer<List<Instance>>.Default.Equals(instances, solwin.instances);
        }

        /// <summary>
        /// GetHashCode method for Solwin class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(instances);
        }

        /// <summary>
        /// ToString method for Solwin lcass
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
