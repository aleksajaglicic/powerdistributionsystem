using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.powerplant
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
                throw new ArgumentException("Cannot genererate more than its own power...");
            }
            
            if (output > 0 && status==false)
            {
                throw new ArgumentException("Cannot generate if plant is off...");
            }
            
            this.power = power;
            this.output = output;
            this.status = status;
        }

        public int turnOnPlant(int generatedPower, int usedPower)
        {
            int ret;
            int pow_needed = usedPower - generatedPower;
            if (pow_needed <= 0)
            {
                power = 1000;
                output = 0; 
                status = false;
                ret=0;

            }
            else
            {
                output = (100 * pow_needed) / power;
                status = true;
                ret=1;
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
            string file = Environment.CurrentDirectory + "/files/Plant_data.txt";


            try
            {
                sw = File.AppendText(file);
                DateTime time = DateTime.Now;
                string write = output.ToString() + "% " + " " + time;

                sw.WriteLine(write);
                sw.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Upis nije uspesan");
                Console.WriteLine(e.StackTrace);
            }
        }

        public void read ()
        {
            StreamReader sr = null;
            string file = Environment.CurrentDirectory + "Plant_data.txt";

            try
            {
                string read = File.ReadAllText(file);
                Console.WriteLine("Powerplant logs: \n {0}",read);

            }
            catch(Exception e)
            {
                //Console.WriteLine("Citanje nije uspesno");
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
