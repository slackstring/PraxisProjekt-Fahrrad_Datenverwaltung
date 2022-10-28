using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxisProjekt_FahrradVerwaltung
{
    public class DataAdded
    {
        //Event
        public event PopUpBikeAddedEventHandler BikeAdded;
        //Methoden
        public void BikeIsAdded()
        {
            if (BikeAdded != null)
            {
                BikeAdded();  //Löst Event aus
            }
        }
    }
     

    public class DataDeleted
    {
        //Event
        public event PopUpBikeDeletedEventHandler BikeDeleted;
        //Methode
        public void BikeIsDeleted()
        {
            if (BikeDeleted != null)
            {
                BikeDeleted();  //Löst Event aus
            }
        }
    }
}
