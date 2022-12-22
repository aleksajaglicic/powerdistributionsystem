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
        private string naziv;
        private int kWh;

        public Consumer(int id = 0, string naziv = "nepoznat", int kWh = 0)
        {
            this.id = id;
            this.naziv = naziv;
            this.kWh = kWh;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public int KWH
        {
            get { return kWh; }
            set { kWh = value; }
        }

        public override String ToString()
        {
            return " " + id + "\t" + naziv + "\t" + "\t" + kWh + "\t";
        }
    }
}
