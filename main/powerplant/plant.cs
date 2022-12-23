using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.powerplant
{
    class plant
    {

        private int snaga;
        private int output;
        private bool status;

        public int Snaga
        {
            get { return snaga; }
            set { snaga = value; }
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
        public plant()
        {
            snaga=1000;
            output=0;
            status=false;
        }
        public plant(int snaga=1000, int output=0, bool status=false)
        {
            this.snaga = snaga;
            this.output = output;
            this.status = status;
        }

        public int ukljuciElektranu(int proizvodnja, int potrosnja) //PRIMA PROIZVODNJU U SISTEMU (solarni paneli i vetrenjace) I POTROSNJU DA BI SE ZNALO KOLIKO TREBA DA GENERISE
        {
            int potrebno = potrosnja - proizvodnja;     //KOLIKO JE POTREBNO STRUJE PROIZVESTI  
            if (potrebno <= 0)      //PANELI I VETRENJACE SU DOVOLJNE ZA NAPAJANJE SISTEMA
            {
                snaga = 1000;                           //KOLIKO ELEKTRANA MOZE DA PROIZVEDE KADA JE UKLJUCENA NA 100%
                output = 0;                             //ELEKTRANA NE PROIZVODI NISTA
                status = false;                         //ELEKTRANA JE ISKLJUCENA
                return 0;                               //VRACA 0 JER JE ISKLJUCENA

            }
            else
            {
                output = (100 * potrebno) / snaga;      //PROIZVODNJA SE POSTAVLJA NA POTREBAN PROCENAT
                status = true;                          //ELEKTRANA JE UKLJUCENA
                return 1;                               //AKO JE UKLJUCENA VRACA 1
            }
            
        }

        public override string ToString()
        {
            return  snaga + "\t|\t" + output+ "\t|\t" + status;
        }

       
    }
}
