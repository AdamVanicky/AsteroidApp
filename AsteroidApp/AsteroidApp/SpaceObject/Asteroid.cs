using System;
using System.Collections.Generic;
using System.Text;

namespace AsteroidApp.SpaceObject
{
    public class Asteroid
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Is_Hazardous { get; set; }
        public string Velocity_kms { get; set; }
        public string Orbiting_Body { get; set; }

        public Asteroid(string name, string id, string is_hazardous, string velocity_kms, string orbiting_body)
        {
            Name = name;
            ID = id;
            Is_Hazardous = is_hazardous;
            Velocity_kms = velocity_kms + " km/s";
            Orbiting_Body = orbiting_body;
        }
    }
}
