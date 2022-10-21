using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxisProjekt_FahrradVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu();
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
                choice = Convert.ToInt32(Console.ReadLine());   
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
            string framesize;
            string material;
            double weight;
            Console.Clear();
            Console.WriteLine("Put in the manufacturers name: ");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Put in the model name: ");
            model = Console.ReadLine();
            Console.WriteLine("Put in the frame size: ");
            framesize = Console.ReadLine();
            Console.WriteLine("Put in the frame material: ");
            material = Console.ReadLine();
            Console.WriteLine("Put in the weight of the frame [kg]: ");
            weight = Convert.ToDouble(Console.ReadLine());
            Bike newBike = new Bike(manufacturer, model, framesize, material, weight);
            //List<Bike> bikes = new List<Bike>();
            BikeList.bikes.Add(newBike);
        }

        static void Check()
        {
            Console.Clear();
            int i = 1;
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
            Console.WriteLine("Enter ID-NR of the bike frame you want to delete");
            int delete = Convert.ToInt32(Console.ReadLine());
            BikeList.bikes.RemoveAt(delete-1);

        }

        static void Compare()
        {
            Console.Clear();
            Console.WriteLine("Put in ID-NR of the first bike frame to compare:");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Put in ID-NR of the second bike frame to compare:");
            int second = Convert.ToInt32(Console.ReadLine());
            BikeList.bikes[first - 1].OutputComplete();
            BikeList.bikes[second - 1].OutputComplete();
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();


        }

        public class BikeList
        {
            public static List<Bike> bikes = new List<Bike>();
        }
    }

 
}
