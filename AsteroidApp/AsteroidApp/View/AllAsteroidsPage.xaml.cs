using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AsteroidApp.SpaceObject;
using AsteroidApp.HTTP_request;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsteroidApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAsteroidsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public AllAsteroidsPage(ObjectSpace osp = null)
        {
            InitializeComponent();
            AllObjects oP = new AllObjects();
            oP.TheObjects.Add(osp);
            BindingContext = oP;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Page p = new AsteroidInfoPage(((ListView)sender).SelectedItem as ObjectSpace, (BindingContext as AllObjects).TheObjects);
            NavigationPage np = new NavigationPage(p);
            await Application.Current.MainPage.Navigation.PushAsync(np);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
