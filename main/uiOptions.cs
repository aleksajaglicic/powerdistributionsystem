using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ConsoleTables;
using powerdistributionsystem.consumer;

namespace powerdistributionsystem
{
    class UiOptions
    {
        private int uiNum;
        private int counter = 0;
        public System.Random random = new System.Random();
        public solwin.Solwin sw = new solwin.Solwin();
        public powerplant.Plant plant = new powerplant.Plant();
        public distributioncenter.Center center = new distributioncenter.Center();
        LogicFunctions listH = new LogicFunctions();
        LogicFunctions list = new LogicFunctions();

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

        /// <summary>
        /// Calls main UI
        /// </summary>
        public void MainUI()
        {
            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(5);
            //var timer = new System.Threading.Timer((e) =>
            //{
            //    ChangeSunWind();
            //}, null, 5000, 30000);

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

        /// <summary>
        /// Calls consumer UI
        /// </summary>
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
            Console.WriteLine("\\\\\\\\ 1.Select Existing Sockets");
            Console.WriteLine("\\\\\\\\ 2.Add Connection Sockets");
            Console.WriteLine("\\\\\\\\ 3.Erase Connection Sockets");
            Console.WriteLine("\\\\\\\\ 4.View all Connected Sockets");
            Console.WriteLine("\\\\\\\\ 5.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                SelectUI();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                AddUI();
            }
            else if (UINum == 3)
            {
                Console.Clear();
                EraseUI();
            }
            else if (UINum == 4)
            {
                Console.Clear();
                ViewSockets();
            }
            else if (UINum == 5)
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

        /// <summary>
        /// Calls select power socket UI
        /// </summary>
        public void SelectUI()
        {
            if (counter < 1)
            {
                listH.ReadFromFile("./files/LoadInstances.txt");
            }

            var table = new ConsoleTable("Id:", "Name: ", "Power:");
            ConsoleTable.From<Consumer>(listH.archive.ToList()).Write();

            if (listH.archive.Count == 0)
            {
                ConsumerUI();
            }
            Console.WriteLine("Enter existing socket based on id:");

            int id = Int32.Parse(Console.ReadLine());

            Consumer c1 = listH.Find(id);
            listH.Remove(id);
            list.Add(c1);
            list.WriteToFile("./files/SocketInstances.txt");

            counter++;

            Console.Clear();
            ConsumerUI();

        }

        /// <summary>
        /// Calls add socket UI
        /// </summary>
        public void AddUI()
        {
            Console.WriteLine("Enter socket id:");

            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter socket name:");

            string name = Console.ReadLine();

            Console.WriteLine("Enter socket power usage:");

            int kwh = Int32.Parse(Console.ReadLine());

            Consumer c = new Consumer(id, name, kwh);

            list.Add(c);
            list.WriteToFile("./files/SocketInstances.txt");
            Console.WriteLine(list);

            Console.Clear();
            ConsumerUI();

        }

        /// <summary>
        /// Calls erase socket UI
        /// </summary>
        public void EraseUI()
        {
            Console.WriteLine("Enter id of socket to erase:");
            int id = Int32.Parse(Console.ReadLine());

            list.Remove(id);
            list.WriteToFile("./files/SocketInstances.txt");
            Console.WriteLine(list);

            Console.Clear();
            ConsumerUI();
        }

        /// <summary>
        /// Calls view socket UI
        /// </summary>
        public void ViewSockets()
        {
            if (list.archive.Count == 0)
            {
                Console.WriteLine("No Instances turned on...");
            }
            else
            {
                var table = new ConsoleTable("Id:", "Name: ", "Power:");
                ConsoleTable.From<Consumer>(list.archive.ToList()).Write();
            }

            Console.WriteLine();
            ConsumerUI();
        }

        /// <summary>
        /// Calls distribution center UI
        /// </summary>
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
            Console.WriteLine("\\\\\\\\ 2.Return to main menu\n");

            Console.WriteLine("Go to option: ");
            UINum = Int32.Parse(Console.ReadLine());

            //Selected options
            if (UINum == 1)
            {
                Console.Clear();
                PowerCalc();
                DistributionCenterUI();
            }
            else if (UINum == 2)
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

        /// <summary>
        /// Calls power calculator UI
        /// </summary>
        public void PowerCalc()
        {
            Console.Clear();

            //To be added
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Calculator UI
            Console.WriteLine("Power Calculator");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            int pC = center.powerCalculator();
            int sP = center.socketPowerUsage();

            if ((pC - sP) < 0)
            {
                if (plant.turnOnPlant(pC, sP) == 1)
                {
                    plant.Save(plant, "./files/PlantData.txt");
                }

                Console.WriteLine("Need additional power... Current Socket Power Usage: " + sP + "% SolarWind Power Generation " + pC + "%");
                Console.WriteLine("Turning on power plant...");

                if ((sP - pC) >= 100)
                {
                    plant.Save(plant, "./files/PlantData.txt");
                    Console.WriteLine("Cannot turn on Power Plant... Power Usage exceeds Power Plant generation...");
                }

            }
            else
            {
                Console.WriteLine("Power Usage fullfiled... Current Socket Power Usage: " + sP + "% SolarWind Power Generation " + pC + "%");
                plant.Status = false;
                plant.Output = 0;
                plant.Save(plant, "./files/PlantData.txt");
            }
        }

        /// <summary>
        /// Calls solar/wind instance UI
        /// </summary>
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

        /// <summary>
        /// Calls add/erase panel/gen UI
        /// </summary>
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

                int choice;
                int choicePower;
                int power;

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Please choose panel or generator (0 or 1):");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                choice = Int32.Parse(Console.ReadLine());
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Please choose rand power value or chosen value (0 or 1):");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                choicePower = Int32.Parse(Console.ReadLine());
                Console.Clear();

                if (choicePower == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Please choose power value:");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    power = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                }
                else
                {
                    power = random.Next(0, 100);
                }

                sw.addInstance(choice, power, DateTime.Now);
                AddEraseSolWinUI();
            }
            else if (UINum == 2)
            {
                Console.Clear();
                int eraseId;

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Enter the id of the instance you wish to erase:");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                eraseId = Int32.Parse(Console.ReadLine());
                Console.Clear();

                sw.eraseInstance(eraseId);
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

        /// <summary>
        /// Calls view panel/gen UI
        /// </summary>
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

        /// <summary>
        /// Calls change panel/gen power UI
        /// </summary>
        public void ChangeSunWind()
        {
            sw.viewList();
            Console.WriteLine();

            int id;
            int power;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Please enter id of instance you wish to change the power of:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            id = Int32.Parse(Console.ReadLine());

            Console.Clear();

            sw.readFromFile();
            if (sw.existsById(id))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Please enter the power you wish to change to:");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                power = Int32.Parse(Console.ReadLine());

                sw.change(id, power);
            }

            Console.WriteLine("Return to previous menu or view change? (0 or 1)");
            UINum = Int32.Parse(Console.ReadLine());

            if (uiNum == 0)
            {
                Console.Clear();
                SolarWindUI();
            }
            else if (uiNum == 1)
            {
                Console.Clear();
                sw.viewList();
                Console.WriteLine("Return to previous menu? (1 for yes)");
                UINum = Int32.Parse(Console.ReadLine());

                if (uiNum == 1)
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
        }

        /// <summary>
        /// Calls power plant UI
        /// </summary>
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

        /// <summary>
        /// Calls power plant status UI
        /// </summary>
        public void PPStatusEG()
        {

            Console.Clear();
            if (plant.Status)
            {
                Console.Write("\n\nCurrent state of Power Plant: ");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("ON\t");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Generated: {0}%\n\n", plant.Output);
            }
            else
            {
                Console.Write("\n\nCurrent state of Power Plant: ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("OFF\t");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Generated: {0}%\n\n", plant.Output);

            }

            PowerPlantUI();
        }

        /// <summary>
        /// Reads power plant log
        /// </summary>
        public void PPLog()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            plant.read("./files/PlantData.txt");
            PowerPlantUI();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
