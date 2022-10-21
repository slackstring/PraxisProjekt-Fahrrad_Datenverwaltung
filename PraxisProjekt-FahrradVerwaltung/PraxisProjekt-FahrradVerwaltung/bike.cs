using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxisProjekt_FahrradVerwaltung
{
    public class Bike
    {
        //Eigenschaften
        private string Manufacturer { get; set; }
        private string Model { get; set; }
        private string FrameSize { get; set; }
        private string Material { get; set; }
        private double Weight { get; set; }
        
        //Konstruktor
        public Bike(string manufacturer, string model, string framesize, string material, double weight)
        {
            Manufacturer = manufacturer;
            Model = model;
            FrameSize = framesize;
            Material = material;
            Weight = weight;
        }

        //Ausgabe Übersicht
        public void OutputOverview()
        {
            Console.Write(" {0} {1}", Manufacturer, Model);
        }

        //Ausgabe Komplett
        public void OutputComplete()
        {
            Console.WriteLine("{0} {1} {2} {3} {4}", Manufacturer, Model,FrameSize, Material, Weight);
        }
    }
}
