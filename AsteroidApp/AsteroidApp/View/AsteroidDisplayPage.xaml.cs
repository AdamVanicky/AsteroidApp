using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AsteroidApp.HTTP_request;
using AsteroidApp.SpaceObject;

namespace AsteroidApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsteroidDisplayPage : ContentPage
    {
        public AsteroidDisplayPage()
        {
            InitializeComponent();
            HTTPrequest req = new HTTPrequest();

            asterList.ItemsSource = req.GiveAsteroids();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new AsteroidInfoPage(((sender as Button).BindingContext) as Asteroid));
        }
    }
}