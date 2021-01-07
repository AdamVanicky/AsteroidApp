using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AsteroidApp.SpaceObject
{
    public class ObjectSpace
    {
        public ObjectSpace(string json)
        {
            JObject jObject = JObject.Parse(json);
            ID = (int)jObject["id"];
            Name = (string)jObject["name"];
            IsHazardous = (bool)jObject["is_potentially_hazardous_asteroid"];
            OrbitingBody = (string)jObject["orbiting_body"];
            IsSentryObject = (bool)jObject["is_sentry_object"];
        }

        public ObjectSpace()
        {

        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; } 

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsHazardous { get; set; } 

        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }

        [JsonProperty("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }
}
