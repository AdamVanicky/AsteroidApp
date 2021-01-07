using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AsteroidApp.SpaceObject;
using System.Net.Http;
using AsteroidApp.View;
using System.Threading.Tasks;


namespace AsteroidApp.HTTP_request
{
    public class HTTPrequest
    {
        public static async Task<ObjectSpace> Request()
        {

            var url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=2021-01-01&end_date=2021-01-02&api_key=7eSRKv50oHBCSXobvWbZma1RrYTf0e1ORMAPPQF5";

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.SerializeObject(responseBody);
            int IDposition = json.IndexOf("id");
            string ID = json.Substring(IDposition-1,1051);
            string IDPerfect = "{" + ID;

            ObjectSpace osp = new ObjectSpace(IDPerfect);
            
            //var js = JsonConvert.SerializeObject(IDPerfect);

            // ObjectSpace osp = JsonConvert.DeserializeObject<ObjectSpace>(js);
            return osp;
        }
    }
}
