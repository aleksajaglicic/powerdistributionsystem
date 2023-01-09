using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.consumer
{
    public class LogicFunctions
    {
        public List<Consumer> archive;
        public LogicFunctions()
        {
            archive = new List<Consumer>();
        }

        public bool Add(Consumer c)
        {
            for (int i = 0; i < archive.Count; i++)
                if ((archive[i]).Id == c.Id)
                    return false;

            archive.Add(c);
            return true;
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < archive.Count; i++)
                if ((archive[i]).Id == id)
                {
                    archive.RemoveAt(i);
                    return true;
                }

            return false;
        }
        public Consumer Find(int id)
        {
            for (int i = 0; i < archive.Count; i++)
                if ((archive[i]).Id == id)
                    return archive[i];

            return null;
        }

        public override String ToString()
        {
            if (archive.Count == 0) return "There are no instances in archive!";

            String str = "";
            foreach (Consumer c in archive)
                str += c + "\n";
            return str;
        }

        public void WriteToFile(string file)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(file);
                sw.WriteLine(this);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void ReadFromFile(string file)
        {
            StreamReader sr = null;
            string name;
            int id;
            int kwh;
            string line;

            try
            {
                sr = new StreamReader(file);

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineParts = line.Split('|');
                    name = lineParts[1];
                    id = Int32.Parse(lineParts[0]);
                    kwh = Int32.Parse(lineParts[2]);

                    archive.Add(new Consumer(id, name, kwh));
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
    }
}