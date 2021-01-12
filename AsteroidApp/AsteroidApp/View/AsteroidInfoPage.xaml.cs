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
    public partial class AsteroidInfoPage : ContentPage
    {
        public AsteroidInfoPage()
        {
            InitializeComponent();
        }
        public AsteroidInfoPage(Asteroid a)
        {
            InitializeComponent();

            Name.Text = a.Name;
            ID.Text = a.ID;
            Velocity_kms.Text = a.Velocity_kms;
            Is_Hazardous.Text = a.Is_Hazardous;
            Orbiting_Body.Text = a.Orbiting_Body;
        }
    }
}