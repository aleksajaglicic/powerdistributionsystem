using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace main.solwin
{
    public class Solwin
    {
        public List<Instance> instances;
        public System.Random random = new System.Random();
        public DateTime timestamp = new DateTime();
        public string file = Environment.CurrentDirectory + "/files/SolarWindInstances.txt";

        public Solwin()
        {
            instances = new List<Instance>();
        }

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

        public void addInstance(int c = 0, int cP = 0, DateTime ? timeChanged = null)
        {
            readFromFile();
            int id = instances.Count;
            writeToFile(id, c, cP, timeChanged);
        }

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

        public void viewList()
        {
            instances.Clear();
            var table = new ConsoleTable("Id:", "Power: ", "Type", "TimeStamp");
            readFromFile();

            ConsoleTable.From<Instance>(instances).Write();
        }

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

        public override bool Equals(object obj)
        {
            return obj is Solwin solwin &&
                   EqualityComparer<List<Instance>>.Default.Equals(instances, solwin.instances);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(instances);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
