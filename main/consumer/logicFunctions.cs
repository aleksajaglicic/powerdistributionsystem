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
        public List<Consumer> arhiva;
        public LogicFunctions()
        {
            arhiva = new List<Consumer>();
        }

        public bool Add(Consumer c)
        {
            for (int i = 0; i < arhiva.Count; i++)
                if ((arhiva[i]).Id == c.Id)
                    return false;

            arhiva.Add(c);
            return true;
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < arhiva.Count; i++)
                if ((arhiva[i]).Id == id)
                {
                    arhiva.RemoveAt(i);
                    return true;
                }

            return false;
        }
        public Consumer Find(int id)
        {
            for (int i = 0; i < arhiva.Count; i++)
                if ((arhiva[i]).Id == id)
                    return arhiva[i];

            return null;
        }

        public override String ToString()
        {
            if (arhiva.Count == 0) return "U arhivi nema uredjaja!";

            String str = "|ID|\tNAZIV\t\t|\tKWH\t|\n";
            foreach (Consumer c in arhiva)
                str += c + "\n";
            return str;
        }

        public void Upisi_u_fajl(string file)
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



        public void Ucitaj_iz_fajla(string file)
        {
            StreamReader sr = null;
            string naziv;
            int id;
            int kwh;
            string linija;

            try
            {
                sr = new StreamReader(file);


                while ((linija = sr.ReadLine()) != null)
                {
                    //razdvajanje po delimiteru |
                    string[] lineParts = linija.Split('|');

                    naziv = lineParts[0];
                    id = Int32.Parse(lineParts[1]);
                    kwh = Int32.Parse(lineParts[2]);

                    arhiva.Add(new Consumer(id, naziv, kwh));
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