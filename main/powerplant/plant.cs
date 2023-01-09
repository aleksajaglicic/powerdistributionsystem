using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.powerplant
{
    public class plant
    {

        private int power=1000;
        private int output=0;
        private bool  status=false;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Output
        {
            get { return output; }
            set { output = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        
        
        public plant(plant p)
        {
            this.power = p.power;
            this.output = p.output;
            this.status = p.status;
        }
        public plant(int power=1000, int output=0, bool status=false)
        {
            if (output > power)
            {
                throw new ArgumentException("Ne moze da proizvodi vise od svoje snage");
            }
            if (output > 0 && status==false)
            {
                throw new ArgumentException("Ne moze da proizvodi struju ako je ugasena");

            }
            this.power = power;
            this.output = output;
            this.status = status;
        }

        public int ukljuciElektranu(int proizvodnja, int potrosnja) //PRIMA PROIZVODNJU U SISTEMU (solarni paneli i vetrenjace) I POTROSNJU DA BI SE ZNALO KOLIKO TREBA DA GENERISE
        {
            int ret;
            int pow_needed = potrosnja - proizvodnja;     //KOLIKO JE POTREBNO STRUJE PROIZVESTI  
            if (pow_needed <= 0)      //PANELI I VETRENJACE SU DOVOLJNE ZA NAPAJANJE SISTEMA
            {
                power = 1000;                           //KOLIKO ELEKTRANA MOZE DA PROIZVEDE KADA JE UKLJUCENA NA 100%
                output = 0;                             //ELEKTRANA NE PROIZVODI NISTA
                status = false;                         //ELEKTRANA JE ISKLJUCENA
                ret=0;                               //VRACA 0 JER JE ISKLJUCENA

            }
            else
            {
                output = (100 * pow_needed) / power;      //PROIZVODNJA SE POSTAVLJA NA POTREBAN PROCENAT
                status = true;                          //ELEKTRANA JE UKLJUCENA
                ret=1;                               //AKO JE UKLJUCENA VRACA 1
            }

            Save(this);
            return ret;
        }

        public override string ToString()
        {
            return  power + "\t|\t" + output+ "\t|\t" + status;
        }

       public void Save(plant p)
        {
            StreamWriter sw = null;
            string file = Environment.CurrentDirectory + "Plant_data.txt"; //lokacija fajla u koji se cuvaju podaci

            try
            {
                sw = File.AppendText(file);                                     //(appandText) da bi se sacuvali prethodni podaci fajla     

                DateTime time = DateTime.Now;                                   //trenutno vreme (timestamp promene rezima elektrane)

                string write = output.ToString() + "% " + " " + time;            //String koji se pise u fajl

                sw.WriteLine(write);                                            //Upis u fajl
                //Console.WriteLine("Upis uspesan");
                sw.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Upis nije uspesan");
                Console.WriteLine(e.StackTrace);
            }
        }

        public void read ()                                 //Funkcija za citanje podataka iz fajla i ispis
        {
            StreamReader sr = null;
            string file = Environment.CurrentDirectory + "Plant_data.txt";      //lokacija fajla

            try
            {
                string read = File.ReadAllText(file);                           //reader sza file
                Console.WriteLine("Powerplant logs: \n {0}",read);              //ispis procitanog sadrzaja fajla

            }
            catch(Exception e)                                                  //hvatanje greske ako se ne cita dobro fajl
            {
                //Console.WriteLine("Citanje nije uspesno");
                Console.WriteLine(e.StackTrace);
            }
        }


    }
}
