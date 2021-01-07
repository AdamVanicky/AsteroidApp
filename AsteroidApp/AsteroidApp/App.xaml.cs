using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AsteroidApp.View;
using AsteroidApp.HTTP_request;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using AsteroidApp.SpaceObject;

namespace AsteroidApp
{
    public partial class App : Application
    {
        public static ObjectSpace osp = new ObjectSpace();
        public App()
        {
            InitializeComponent();
            GiveObject();
            MainPage = new NavigationPage(new AllAsteroidsPage(osp)); 
        }
        static async void GiveObject()
        {
            osp = await HTTPrequest.Request();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
