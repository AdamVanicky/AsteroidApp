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
        const string url = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=hOiwbtAiz8jSqDxppkeARVfim1O48lbatB7VY1By";

        private HttpClient client = new HttpClient();

        public async Task<ObjectSpace> Request()
        {
            return await client.GetFromJsonAsync<ObjectSpace>(url).ConfigureAwait(false);
        }

        public List<Asteroid> GiveAsteroids()
        {
            List<Asteroid> asteroids = new List<Asteroid>();
            try 
            {
                ObjectSpace response = Request().Result;
                foreach(NearEarthObject nEo in response.nearEarthobjects)
                {
                    CloseApproachData cad = new CloseApproachData();
                    asteroids.Add(new Asteroid(nEo.name, nEo.id, nEo.is_potentially_hazardous_asteroid.ToString(), cad.relative_velocity.kilometers_per_second, cad.orbiting_body));
                }
                return asteroids;
            }
            catch
            {
                throw new Exception("Fail encountered");
            }
        }
    }
}
