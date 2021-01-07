using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace AsteroidApp.SpaceObject
{
    public class AllObjects
    {
        public ObservableCollection<ObjectSpace> TheObjects { get; set; }

        public AllObjects()
        {
            TheObjects = new ObservableCollection<ObjectSpace>();
        }
    }
}
