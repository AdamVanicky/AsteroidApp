using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AsteroidApp.SpaceObject;
using System.Net.Http;
using System.Net.Http.Json;
using AsteroidApp.View;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Linq;


namespace AsteroidApp.HTTP_request
{
    public class HTTPrequest
    {
        const string url = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=kTlB1068LXF3IZeIHqWRPhMeFSNgvZVKyPOCRoRd";

        protected HttpClient client = new HttpClient();

        public async Task<ObjectSpace> Request()
        {
            return await client.GetFromJsonAsync<ObjectSpace>(url).ConfigureAwait(false);
        }

        public List<Asteroid> GiveAsteroids()
        {
            List<Asteroid> asteroids = new List<Asteroid>();

                ObjectSpace response = Request().Result;
                foreach(NearEarthObject nEo in response.near_earth_objects)
                {
                    CloseApproachData cad = nEo.close_approach_data[0];
                    asteroids.Add(new Asteroid(nEo.name, nEo.id, nEo.is_potentially_hazardous_asteroid.ToString(), cad.relative_velocity.kilometers_per_second, cad.orbiting_body));
                }
                return asteroids;
            
        }
    }
}
