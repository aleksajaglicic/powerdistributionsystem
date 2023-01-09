using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.consumer
{
    public class Consumer
    {
        private int id;
        private string name;
        private int kWh;

        public Consumer(int id = 0, string name = "unknown", int kWh = 0)
        {
            this.id = id;
            this.name = name;
            this.kWh = kWh;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int KWH
        {
            get { return kWh; }
            set { kWh = value; }
        }

        public override String ToString()
        {
            return id + "\t|\t" + name + "\t|\t" + kWh;
        }
    }
}
