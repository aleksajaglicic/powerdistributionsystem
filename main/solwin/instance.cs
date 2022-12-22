using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.solwin
{
    public class Instance
    {
        private int id;
        private int idSW;
        private int power;
        private DateTime timeChanged;

        public Instance(int id, int idSW, int power, DateTime timeChanged)
        {
            this.id = id;
            this.idSW = idSW;
            this.power = power;
            this.timeChanged = timeChanged;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int IDSW
        {
            get { return idSW; }
            set { idSW = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public DateTime TimeChanged
        {
            get { return timeChanged; }
            set { timeChanged = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is Instance instance &&
                   id == instance.id &&
                   power == instance.power &&
                   idSW == instance.idSW &&
                   timeChanged == instance.timeChanged;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, power, idSW, timeChanged);
        }

        public override string ToString()
        {
            return id + "\t|\t" + power + "\t|\t" + idSW + "\t|\t" + timeChanged;
        }
    }
}
