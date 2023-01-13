using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerdistributionsystem.powerplant
{
    /// <summary>
    /// This class represent a power plant
    /// </summary>
    public class Plant
    {
        private int output = 0;
        /// <summary>
        /// Power plant status
        /// </summary>
        public bool status = false;
        /// <summary>
        /// File path for power plant log file
        /// </summary>
        public string file = Environment.CurrentDirectory + "/files/PlantData.txt";

        /// <summary>
        /// Output power from power plant
        /// </summary>
        public int Output
        {
            get { return output; }
            set { output = value; }
        }

        /// <summary>
        /// Power plant status
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Constructor for power plant class
        /// </summary>
        public Plant(Plant p)
        {
            this.output = p.output;
            this.status = p.status;
        }

        /// <summary>
        /// Constructor for power plant class
        /// </summary>
        public Plant(int output = 0, bool status = false)
        {
            this.output = output;
            this.status = status;
        }

        /// <summary>
        /// Method for turning on power plant
        /// </summary>
        /// <param name="generatedPower">Power from panel/gen instances</param>
        /// <param name="usedPower">Power from socket instances</param>
        /// <returns>bool which determines whether the power plant is on</returns>
        public int turnOnPlant(int generatedPower, int usedPower)
        {
            int ret;
            int pow_needed = usedPower - generatedPower;
            if (pow_needed <= 0)
            {
                output = 0;
                status = false;
                ret = 0;
            }
            else if (pow_needed <= 100)
            {
                output = pow_needed;
                status = true;
                ret = 1;
            }
            else
            {
                output = 0;
                status = false;
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// ToString method for power plant class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return output + "\t|\t" + status;
        }

        /// <summary>
        /// Saves power plant information to log file
        /// </summary>
        /// <param name="p">Power Plant instance</param>
        /// <param name="file">Output file</param>
        public void Save(Plant p, string file)
        {
            StreamWriter sw = null;
            string onOff = "";

            if (p.status)
            {
                onOff += "ON";
            }
            else
            {
                onOff = "OFF";
            }

            try
            {
                sw = File.AppendText(file);
                DateTime time = DateTime.Now;
                string write = output.ToString() + "% " + " " + time + " Turned: " + onOff;

                sw.WriteLine(write);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        /// <summary>
        /// Reads power plant log from log file
        /// </summary>
        /// <param name="file">Output file</param>
        public void read(string file)
        {
            try
            {
                string read = File.ReadAllText(file);
                Console.WriteLine("Powerplant logs: \n{0}", read);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
