using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    class UiOptions
    {
        private int uiNum;

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

            Console.WriteLine("\nPlease select one of the following:");
            Console.WriteLine("\\\\\\\\ 1.Add/Erase Connection Sockets");
            Console.WriteLine("\\\\\\\\ 2.View all Connected Sockets");
            Console.WriteLine("\\\\\\\\ 3.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());
            
            //Selected options
            if(UINum == 1)
            {
                Console.Clear();
                AddEraseUI();
            }
            else if(UINum == 2)
            {
                Console.Clear();
                ViewSockets();
            }
            else if(UINum == 3)
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

        public void AddEraseUI()
        {
            //To be added
        }

        public void ViewSockets()
        {
            //To be added
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

            // Main Consumer UI
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
            //To be added
        }

        public void ViewPanelGen()
        {
            //To be added
        }

        public void ChangeSunWind()
        {
            //To be added
        }

        public void PowerPlantUI()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Main Distribution Center UI
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
