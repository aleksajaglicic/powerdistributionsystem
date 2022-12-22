using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ConsoleTables;

namespace main.solwin
{
    public class Solwin
    {
        List<Instance> instances;
        public System.Random random = new System.Random();
        public DateTime timestamp = new DateTime();
        //string file = Path.Combine(Environment.CurrentDirectory, @"main\solwin\", "SolarWindInstances.txt");
        public string file = @"C:\Users\aleksa2\source\main\solwin\SolarWindInstances.txt";

        public Solwin()
        {
            instances = new List<Instance>();
        }

        public void addInstance(int c = 0, int cP = 0, int P = 0)
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
                //Unit Testing
                //power = P;
                Console.Clear();
            }
            else
            {
                power = random.Next(0, 100);
            }

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
                    //Unit Testing
                    //timeChanged = System.Convert.ToDateTime("22/12/2022 7:31:20 pm");

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

            int id = instances.Count;

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
                    sw.Close(); 
                } 
                catch (Exception) { }
            }
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

            StreamReader sr = null;
            int id;
            int idSW;
            int power;
            string lines;
            DateTime timeChanged;

            try
            {
                sr = new StreamReader(file);

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] lineParts = lines.Split('|');
                    id = Int32.Parse(lineParts[0]);
                    power = Int32.Parse(lineParts[1]);
                    idSW = Int32.Parse(lineParts[2]);
                    timeChanged = Convert.ToDateTime(lineParts[3]);

                    Instance instance = new Instance(id, idSW, power, timeChanged);
                    instances.Add(instance);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(sr != null)
                {
                    sr.Close();
                }
            }

            for(int i = 0; i < instances.Count; i++)
            {
                if(eraseId == instances[i].ID)
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
                        catch (Exception) {}
                    }
                }
            }
        }

        public void viewList()
        {
            instances.Clear();
            StreamReader sr = null;
            string lines;
            int id;
            int power;
            int idSW;
            DateTime timeChanged;
            //var table = new ConsoleTable("Id:", "Power: ", "Type", "TimeStamp");

            try
            {
                sr = new StreamReader(file);

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] lineParts = lines.Split('|');
                    id = Int32.Parse(lineParts[0]);
                    power = Int32.Parse(lineParts[1]);
                    idSW = Int32.Parse(lineParts[2]);
                    timeChanged = Convert.ToDateTime(lineParts[3]);

                    Instance instance = new Instance(id, idSW, power, timeChanged);
                    instances.Add(instance);
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

           //ConsoleTable.From<Instance>(instances).Write();
            Console.WriteLine("Id:\t\tPower:\t\tIdSW:\t\tTimeStamp:");
            foreach(Instance instance in instances)
            {
                Console.WriteLine(instance);
            }
        }

        public void changePower()
        {

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
