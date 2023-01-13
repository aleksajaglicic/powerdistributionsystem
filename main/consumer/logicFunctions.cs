using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerdistributionsystem.consumer
{
    /// <summary>
    /// This class performs consumer methods
    /// </summary>
    public class LogicFunctions
    {
        /// <summary>
        /// List used for methods
        /// </summary>
        public List<Consumer> archive;
        /// <summary>
        /// Constructor for logic functions class
        /// </summary>
        public LogicFunctions()
        {
            archive = new List<Consumer>();
        }

        /// <summary>
        /// Add socket instance method
        /// </summary>
        /// <param name="c">Consumer instance</param>
        /// <returns>boolean which is the success/failure of the addition</returns>
        public bool Add(Consumer c)
        {
            for (int i = 0; i < archive.Count; i++)
                if ((archive[i]).Id == c.Id)
                    return false;

            archive.Add(c);
            return true;
        }

        /// <summary>
        /// Remove socket instance method
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <returns>boolean which is the success/failure of the removal</returns>
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

        /// <summary>
        /// Method for finding instance in list
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <returns>socket instance from list</returns>
        public Consumer Find(int id)
        {
            for (int i = 0; i < archive.Count; i++)
                if ((archive[i]).Id == id)
                    return archive[i];

            return null;
        }

        /// <summary>
        /// ToString method for logic functions class
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            if (archive.Count == 0) return "There are no instances in archive!";

            String str = "";
            foreach (Consumer c in archive)
                str += c + "\n";
            return str;
        }

        /// <summary>
        /// Writes string to file
        /// </summary>
        /// <param name="file">Output file</param>
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

        /// <summary>
        /// Reads instances from file and adds them to the socket list
        /// </summary>
        /// <param name="file">Input file</param>
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