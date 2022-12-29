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
        List<Instance> instances;
        public System.Random random = new System.Random();
        public DateTime timestamp = new DateTime();
        public string file = Environment.CurrentDirectory + "/SolarWindInstances.txt";

        public Solwin()
        {
            instances = new List<Instance>();
        }

        public void readFromFile(List<Instance> instances)
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

        public void readFromFileTest(List<Instance> instances, string file)
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

        public void writeToFile(int id, int choice, int power)
        {
            Instance instance = new Instance(id, choice, power, DateTime.Now);

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

        public void writeToFileTest(int id, int choice, int power, DateTime dateTime, string file)
        {
            Instance instance = new Instance(id, choice, power, dateTime);
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

        public void addInstance(int c = 0, int cP = 0)
        {
            int choice;
            int choicePower;
            int power;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please choose panel or generator (0 or 1):");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            choice = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please choose rand power value or chosen value (0 or 1):");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            choicePower = Int32.Parse(Console.ReadLine());
            Console.Clear();

            if (choicePower == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Please choose power value:");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                power = Int32.Parse(Console.ReadLine());
                Console.Clear();
            }
            else
            {
                power = random.Next(0, 100);
            }

            readFromFile(instances);
            int id = instances.Count;
            writeToFile(id, choice, power);
        }

        public void addInstanceTest(int c = 0, int cP = 0, string file = "")
        {
            int choice = c;
            int choicePower = cP;
            DateTime dateTime = Convert.ToDateTime("22/12/2022 7:31:20 pm");

            int id = instances.Count;
            writeToFileTest(id, choice, choicePower, dateTime, file);
        }

        public void eraseInstance()
        {
            instances.Clear();
            int eraseId;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Enter the id of the instance you wish to erase:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            eraseId = Int32.Parse(Console.ReadLine());
            Console.Clear();

            readFromFile(instances);

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

        public void eraseInstanceTest(int eraseId, string file)
        {
            List<Instance> instances = new List<Instance>();

            readFromFileTest(instances, file);

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
            readFromFile(instances);

            ConsoleTable.From<Instance>(instances).Write();
        }

        public bool existsById(int id, List<Instance> instances)
        {
            readFromFile(instances);
            
            for(int i = 0; i < instances.Count; i++)
            {
                if(id == instances[i].ID)
                {
                    return true;
                }
            }

            return false;
        }

        public void insertChange(List<Instance> instances)
        {
            string text = "";
            string file = Environment.CurrentDirectory + "/SolarWindInstances.txt";
            StreamWriter sw = null;

            for (int i = 0; i < instances.Count; i++)
            {
                text += instances[i].ToString();
                if( i != instances.Count - 1)
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

        public void change(int id, int power, List<Instance> instances)
        {
            for (int i = 0; i < instances.Count; i++)
            {
                if (id == instances[i].ID)
                {
                    instances[i].Power = power;
                    instances[i].TimeChanged = DateTime.Now;
                }

                insertChange(instances);
            }
        }

        public void changePower()
        {
            viewList();
            Console.WriteLine();

            int id;
            int power;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please enter id of instance you wish to change the power of:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            id = Int32.Parse(Console.ReadLine());

            Console.Clear();

            readFromFile(instances);
            if(existsById(id, instances))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Please enter the power you wish to change to:");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                power = Int32.Parse(Console.ReadLine());

                change(id, power, instances);
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
