using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerdistributionsystem.solwin
{
    /// <summary>
    /// This class represents a solar panel or a generator instance
    /// </summary>
    public class Instance
    {
        private int id;
        private int idSW;
        private int power;
        private DateTime timeChanged;

        /// <summary>
        /// Constructor for instance class
        /// </summary>
        /// <param name="id">Instance ID</param>
        /// <param name="idSW">Instance type ID</param>
        /// <param name="power">Instance power value</param>
        /// <param name="timeChanged">Power change date</param>
        public Instance(int id, int idSW, int power, DateTime timeChanged)
        {
            this.id = id;
            this.idSW = idSW;
            this.power = power;
            this.timeChanged = timeChanged;
        }

        /// <summary>
        /// Instance ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Instance type ID
        /// </summary>
        public int IDSW
        {
            get { return idSW; }
            set { idSW = value; }
        }

        /// <summary>
        /// Instance power value
        /// </summary>
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        /// <summary>
        /// Power changed date
        /// </summary>
        public DateTime TimeChanged
        {
            get { return timeChanged; }
            set { timeChanged = value; }
        }

        /// <summary>
        /// Instance equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Instance instance &&
                   id == instance.id &&
                   power == instance.power &&
                   idSW == instance.idSW &&
                   timeChanged == instance.timeChanged;
        }

        /// <summary>
        /// Instance GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(id, power, idSW, timeChanged);
        }

        /// <summary>
        /// ToString method for Instance class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return id + "\t|\t" + power + "\t|\t" + idSW + "\t|\t" + timeChanged;
        }
    }
}
