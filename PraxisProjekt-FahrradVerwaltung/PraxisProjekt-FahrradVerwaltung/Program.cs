using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PraxisProjekt_FahrradVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Andre\Documents\BikeManagment\BikeManagmentDataFile.txt";
            FileInfo file = new FileInfo(path);
            if (file.Exists == false)
            {
                //Datei nicht vorhanden -> Datei erzeugen
                file.Create().Close();
            }
            else
            {
                //Datei vorhanden -> Datei lesen:
                StreamReader sr = new StreamReader(path);
                int nLines = System.IO.File.ReadAllLines(path).Length;
                string[] buffer = new string[nLines];
                string readLine;
                string readResultTemp;
                int countDivide;
                int countCopy;
                string readManu;
                string readModell;
                string readFramesize;
                string readMaterial;
                double readWeight;
                
                for (int i=0; i<nLines; i++)
                {
                    countCopy = 0;
                    countDivide = 0;
                    readLine = sr.ReadLine();
                    char[] tempLine = new char[readLine.Length];

                    for (int j=0; j<tempLine.Length; j++)
                    {
 
                        if (readLine[j] != '#')
                        {
                            tempLine[j] = readLine[j];

                            
                        }
                        else
                        {
                           // readResultTemp = new string(tempLine);
                            countDivide++;
                        }
                        switch (countDivide)
                        {
                            case 0:
                                break;
                            case 1:
                                readManu = new string(tempLine);
                                break;
                       

                        }
                    }

                  /*  bool abortWhile = false;
                    int k = 0;
                    while (abortWhile = false)
                    {
                        if (tempLine[k] /= "#")
                        {

                        }
                    }*/
                }
                
                sr.Close();
                Console.ReadKey();
            }
            MainMenu();
            //Datei beschreiben:
            StreamWriter sw = new StreamWriter(path,true);  
            foreach(Bike b in BikeList.bikes)
            {               
                sw.Write(b.Manufacturer);
                sw.Write("#");
                sw.Write(b.Model);
                sw.Write("#");
                sw.Write(b.FrameSize);
                sw.Write("#");
                sw.Write(b.Material);
                sw.Write("#");
                sw.Write(b.Weight);
                sw.Write("#");
                sw.Write("\n");
            }
            sw.Close();
        }
        static void MainMenu()
        {

            int choice = 0;
            while (choice == 0)
            {
                Console.Clear();
                Console.WriteLine("#########################################");
                Console.WriteLine("### Bike Frame Management ###############");
                Console.WriteLine("#########################################");
                Console.WriteLine("\n\nMain Menu");
                Console.WriteLine("\n1)  Add Bike Frame");
                Console.WriteLine("2)  Delete Bike Frame");
                Console.WriteLine("3)  Check Available Bike Frames");
                Console.WriteLine("4)  Compare Bike Frames");
                Console.WriteLine("5)  Exit");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong input! Choose a number from 1 to 5. Hit any key to try again!");
                    Console.ReadKey();
                }
                if (choice < 0 || choice > 6)
                {
                    choice = 0;
                    continue;
                }
                switch (choice)
                {
                    case 1: Add();
                            choice = 0;
                        break;

                    case 2: Delete();
                            choice = 0;
                        break;
                    case 3: Check();
                            choice = 0;
                        break;
                    case 4: Compare();
                            choice = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        static void Add()
        {
            string manufacturer;
            string model;
            string framesize="M";
            string material="Alloy";
            double weight = 0;
            Console.Clear();
            Console.WriteLine("Put in the manufacturers name: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Put in the model name: ");
            model = Console.ReadLine();
            bool abortWhileSize = false;
            while (abortWhileSize == false)
            {
                Console.WriteLine("Put in the frame size [S / M / L / XL]: ");             
                framesize = Console.ReadLine();
                framesize = framesize.ToUpper();
                if (framesize == "S" || framesize == "M" || framesize=="L" || framesize=="XL")
                {
                    abortWhileSize = true; 
                }
                else
                {
                    Console.WriteLine("Wrong input, type one of the following chars: [S / M / L / XL] ");
                }
            }
            bool abortWhileMaterial = false;
            while (abortWhileMaterial == false)
            {
                Console.WriteLine("Put in the frame material [Alloy / Carbon / Hybrid]: ");
                material = Console.ReadLine();
                material = char.ToUpper(material[0]) + material.Substring(1).ToLower();
                if (material == "Alloy" || material == "Carbon" || material == "Hybrid")
                {
                    abortWhileMaterial = true;
                }
                else
                {
                    Console.WriteLine("Wrong input, type one of the following materials: [Alloy / Carbon / Hybrid]");
                }
            }
            bool abortWhileWeight = false;
            while (abortWhileWeight == false)
            {
                Console.WriteLine("Put in the weight of the frame [kg]: ");
                try
                {
                    weight = Convert.ToDouble(Console.ReadLine());
                    abortWhileWeight = true;
                }
                catch
                {
                    Console.WriteLine("Wrong input, type in a weight according to following format: [0.000]kg");
                }
            }
            Bike newBike = new Bike(manufacturer, model, framesize, material, weight);
            //List<Bike> bikes = new List<Bike>();
            BikeList.bikes.Add(newBike);
            //PopUp "Daten erfolgreich hinzugefügt" als Event auslösen
            DataAdded newFrame = new DataAdded();
            PopUps added = new PopUps();
            newFrame.BikeAdded += added.BikeAdded;    //Listener abonniert das Event
            newFrame.BikeIsAdded();                   //Event auslösen
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        static void Check()
        {
            Console.Clear();
            int i = 1;
            if (BikeList.bikes.Count == 0)
            {
                Console.WriteLine("No Data available! Add data sets first!");
            }
            foreach (Bike b in BikeList.bikes)
            {
                Console.Write(i);
                b.OutputOverview();
                Console.Write("\n");
                i++;
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        static void Delete()
        {
            Console.Clear();
            if (BikeList.bikes.Count == 0)
            {
                Console.WriteLine("No Data available! Add data first!");
                Console.WriteLine("\nPress any key to go back to main menu");
                Console.ReadKey();
            }
            else
            {
                bool abortWhileDelete = false;
                while (abortWhileDelete == false)
                {
                    Console.WriteLine("Enter ID-NR of the bike frame you want to delete");
                    try
                    {
                        int delete = Convert.ToInt32(Console.ReadLine());
                        BikeList.bikes.RemoveAt(delete - 1);
                        //PopUp "Daten erfolgreich gelöscht" als Event auslösen
                        DataDeleted deleteFrame = new DataDeleted();
                        PopUps deleted = new PopUps();
                        deleteFrame.BikeDeleted += deleted.BikeDeleted;  //Listener abonniert das Event
                        deleteFrame.BikeIsDeleted();
                        abortWhileDelete = true;
                        Console.WriteLine("\nPress any key to go back to main menu");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input! Enter a valid number!");
                    }
                }
            }
          
                
           
        }

        static void Compare()
        {
           
            Console.Clear();
            if (BikeList.bikes.Count < 2)
            {
                Console.WriteLine("Not enough data available! Add at least 2 data sets to start comparison!");
                Console.WriteLine("\nPress any key to go back to main menu");
                Console.ReadKey();
            }
            else
            {
                bool abortWhileCompare = false;
                while (abortWhileCompare == false)
                {
                    try
                    {
                        
                        Console.WriteLine("Put in ID-NR of the first bike frame to compare:");
                        int first = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Put in ID-NR of the second bike frame to compare:");
                        int second = Convert.ToInt32(Console.ReadLine());
                        abortWhileCompare = true;
                        if (Math.Abs(first) > BikeList.bikes.Count || Math.Abs(second) > BikeList.bikes.Count)
                        {
                            Console.WriteLine("Wrong input! No data sets available for put in values!");
                            Console.WriteLine("\nPress any key to go back to main menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            BikeList.bikes[Math.Abs(first) - 1].OutputComplete();
                            BikeList.bikes[Math.Abs(second) - 1].OutputComplete();
                            Console.WriteLine("\nPress any key to go back to main menu");
                            Console.ReadKey();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input, type in a number!");
                    }
                }

                

            }

        }

        //Definition einer globalen Liste damit alle Funktionen darauf zugreifen können
        public class BikeList
        {
            public static List<Bike> bikes = new List<Bike>();
        }

    }

    //Definition von Delegaten um Events zu triggern
    public delegate void PopUpBikeAddedEventHandler();    //PopUp "Daten hinzugefügt"
    public delegate void PopUpBikeDeletedEventHandler();  //PopUp "Daten gelöscht"
}
