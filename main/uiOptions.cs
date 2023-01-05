using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.consumer;
using ConsoleTables;

namespace main
{
    class UiOptions
    {
        private int uiNum;
        private solwin.Solwin sw = new solwin.Solwin();
        LogicFunctions pomocna = new LogicFunctions();
        LogicFunctions lista= new LogicFunctions();
        private int brojac = 0;

        public int UINum
        {
            get { return uiNum; }
            set { uiNum = value; }
        }
        
        public UiOptions(int ui)
        {
            UINum = ui;
        }

        public UiOptions() { }

        public void MainUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main System UI
            Console.WriteLine("Welcome to PROJECT: Power Distribution System");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.Consumer UI");
            Console.WriteLine("\\\\\\\\ 2.Distribution Center UI");
            Console.WriteLine("\\\\\\\\ 3.Solar panel and Wind generator UI");
            Console.WriteLine("\\\\\\\\ 4.Hydroelectric Power Plant UI");
            Console.WriteLine("\\\\\\\\ 5.Close App\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            // Selected options
            if (UINum == 1)
            {
                Console.Clear();
                ConsumerUI();

            }
            else if (UINum == 2)
            {
                Console.Clear();
                DistributionCenterUI();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                SolarWindUI();
            }
            else if (UINum == 4)
            {
                Console.Clear();
                PowerPlantUI();
            }
            else if (UINum == 5)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                MainUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ConsumerUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Consumer UI
            Console.WriteLine("Consumer UI");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            ////////

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 0.Select Existing Sockets");
            Console.WriteLine("\\\\\\\\ 1.Add Connection Sockets");
            Console.WriteLine("\\\\\\\\ 2.Erase Connection Sockets");
            Console.WriteLine("\\\\\\\\ 3.View all Connected Sockets");
            Console.WriteLine("\\\\\\\\ 4.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 0)
            {
                Console.Clear();
                SelectUI();
            }
            else if (UINum == 1)
            {
                Console.Clear();
                AddUI();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                EraseUI();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                ViewSockets();
            }
            else if (UINum == 4)
            {
                Console.Clear();
                MainUI();
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                ConsumerUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void SelectUI()
        {
            if (brojac < 1)
            {
                pomocna.Ucitaj_iz_fajla(@"Ucitavanje.txt");
            }
            Console.WriteLine(pomocna);
            Console.WriteLine();

            if (pomocna.arhiva.Count == 0)
            {
                ConsumerUI();
            }
            Console.WriteLine("Izaberi postojeci prikljucak na osnovu ID");

            int id = Int32.Parse(Console.ReadLine());

            Consumer c1 = pomocna.Find(id);
            pomocna.Remove(id);
            lista.Add(c1);
            lista.Upisi_u_fajl("TestPogled.txt");

            brojac++;

            Console.Clear();
            ConsumerUI();

        }

        public void AddUI()
        {
            Console.WriteLine("Unesite ID od novog prikljucka ");

            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Unesite naziv od novog prikljucka ");

            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite potrosnju u kWH od novog prikljucka ");

            int kwh = Int32.Parse(Console.ReadLine());

            Consumer c = new Consumer(id, naziv, kwh);

            lista.Add(c);
            lista.Upisi_u_fajl("TestPogled.txt");
            Console.WriteLine(lista);

            Console.Clear();
            ConsumerUI();

        }

        public void EraseUI()
        {
            Console.WriteLine("Unesite ID od prikljucka kojeg zelite da obriste");
            int id = Int32.Parse(Console.ReadLine());

            lista.Remove(id);
            lista.Upisi_u_fajl("TestPogled.txt");
            Console.WriteLine(lista);

            Console.Clear();
            ConsumerUI();

        }


        public void ViewSockets()
        {
            Console.WriteLine(lista);
            lista.Upisi_u_fajl("TestPogled.txt");
            ConsumerUI();

        }

        public void DistributionCenterUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Distribution Center UI
            Console.WriteLine("Distribution Center UI");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.Power Generation Calculator");
            Console.WriteLine("\\\\\\\\ 2.View Power Plant request state");
            Console.WriteLine("\\\\\\\\ 3.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                PowerCalc();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                PlantState();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                MainUI();
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                DistributionCenterUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void PowerCalc()
        {
            //To be added
        }

        public void PlantState()
        {
            //To be added
        }

        public void SolarWindUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Solar and Wind UI
            Console.WriteLine("Solar panel and Wind generator UI");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.Add/Erase Instances of panels or generators");
            Console.WriteLine("\\\\\\\\ 2.View all working panels and generators");
            Console.WriteLine("\\\\\\\\ 3.Change Sun/Wind values");
            Console.WriteLine("\\\\\\\\ 4.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                AddEraseSolWinUI();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                ViewPanelGen();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                ChangeSunWind();
            }
            else if (UINum == 4)
            {
                Console.Clear();
                MainUI();
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                SolarWindUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void AddEraseSolWinUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Solar and Wind UI
            Console.WriteLine("Solar panel and Wind generator UI");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.Add Instances of panels or generators");
            Console.WriteLine("\\\\\\\\ 2.Erase Instances of panels or generators");
            Console.WriteLine("\\\\\\\\ 3.Return to previous menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                sw.addInstance();
                AddEraseSolWinUI();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                sw.eraseInstance();
                AddEraseSolWinUI();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                SolarWindUI();
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                SolarWindUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ViewPanelGen()
        {
            sw.viewList();
            Console.WriteLine("Return to previous menu? (1 for yes)");
            UINum = Int32.Parse(Console.ReadLine());

            if (uiNum == 1)
            {
                Console.Clear();
                SolarWindUI();
            }
        }

        public void ChangeSunWind()
        {
            sw.changePower();
            Console.WriteLine("Return to previous menu? (1 for yes)");
            UINum = Int32.Parse(Console.ReadLine());

            if (uiNum == 1)
            {
                Console.Clear();
                SolarWindUI();
            }
        }

        public void PowerPlantUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Power Plant UI
            Console.WriteLine("Power Plant UI");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.View curent Power Plant status and energy generation");
            Console.WriteLine("\\\\\\\\ 2.View Power Plant log");
            Console.WriteLine("\\\\\\\\ 3.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                PPStatusEG();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                PPLog();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                MainUI();
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("ERROR: ui number out of range... Try again");
                PowerPlantUI();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        public void PPStatusEG()
        {
            //To be added
        }

        public void PPLog()
        {
            //To be added
        }
    }
}
