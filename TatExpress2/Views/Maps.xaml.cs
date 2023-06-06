using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TatExpress2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maps : ContentPage
    {
        public Maps()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            // Set the initial map position
            var initialPosition = new Position(37.79762, -122.40181); // Replace with your desired coordinates
            var mapSpan = MapSpan.FromCenterAndRadius(initialPosition, Distance.FromMiles(1));
            myMap.MoveToRegion(mapSpan);

            // Add a marker to the map
            var marker = new Pin
            {
                Label = "Marker Title",
                Position = new Position(37.79762, -122.40181) // Replace with the marker's coordinates
            };
            myMap.Pins.Add(marker);

        }
    }
}