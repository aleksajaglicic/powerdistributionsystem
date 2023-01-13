using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerdistributionsystem.consumer
{
    /// <summary>
    /// This class represents a consumer instance
    /// </summary>
    public class Consumer
    {
        private int id;
        private string name;
        private int kWh;

        /// <summary>
        /// Constructor for consumer instance
        /// </summary>
        /// <param name="id">Socket ID</param>
        /// <param name="name">Socket name</param>
        /// <param name="kWh">Socket power value</param>
        public Consumer(int id = 0, string name = "unknown", int kWh = 0)
        {
            this.id = id;
            this.name = name;
            this.kWh = kWh;
        }

        /// <summary>
        /// Socket ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Socket name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Socket power value
        /// </summary>
        public int KWH
        {
            get { return kWh; }
            set { kWh = value; }
        }

        /// <summary>
        /// ToString method for consumer class
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return id + "|" + name + "|" + kWh;
        }
    }
}
