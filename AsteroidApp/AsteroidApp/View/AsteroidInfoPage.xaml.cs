using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AsteroidApp.SpaceObject;
using System.ComponentModel;

namespace AsteroidApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PageViewModel(ObjectSpace osp)
        {
            Name = osp.Name;
            ID = osp.ID;
            IsHazardous = osp.IsHazardous;
            OrbitingBody = osp.OrbitingBody;
            IsSentryObject = osp.IsSentryObject;
        }

        public string hereName;
        public string Name
        {
            get { return hereName; }
            set
            {
                hereName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public int hereID;
        public int ID
        {
            get { return hereID; }
            set
            {
                hereID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
            }
        }

        public bool hereIsHazardous;
        public bool IsHazardous
        {
            get { return hereIsHazardous; }
            set
            {
                hereIsHazardous = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Is Hazardous"));
            }
        }

        public string hereOrbitingBody;
        public string OrbitingBody
        {
            get { return hereOrbitingBody; }
            set
            {
                hereOrbitingBody = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Orbiting Body"));
            }
        }

        public bool hereIsSentryObject;
        public bool IsSentryObject
        {
            get { return hereIsSentryObject; }
            set
            {
                hereIsSentryObject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Is Sentry Object"));
            }
        }

        public ObjectSpace ChangedObject()
        {
            ObjectSpace p = new ObjectSpace
            {
                Name = this.Name,
                ID = this.ID,
                IsHazardous = this.IsHazardous,
                OrbitingBody = this.OrbitingBody,
                IsSentryObject = this.IsSentryObject
        };
            return p;
        }
    }
    public partial class AsteroidInfoPage : ContentPage
    {
        ObservableCollection<ObjectSpace> oCollection;
        public AsteroidInfoPage()
        {
            InitializeComponent();
        }
        public AsteroidInfoPage(ObjectSpace osp, ObservableCollection<ObjectSpace> collection)
        {
            InitializeComponent();
            PageViewModel pvm = new PageViewModel(osp);
            BindingContext = pvm;
            oCollection = collection;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            oCollection.Add((BindingContext as PageViewModel).ChangedObject());
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}