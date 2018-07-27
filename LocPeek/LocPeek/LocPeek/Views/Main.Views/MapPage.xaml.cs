using LocPeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using LocPeek.delegat;
using Xamarin.Forms.Maps;

namespace LocPeek.Views.Main.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private GetGps gps;


        public MapPage()
        {
            InitializeComponent();
            gps = new GetGps();
            StartPosition();
            gps.PositionChangedEventArgs += PositionChanged;
        }

        private void PositionChanged(object sender, PositionChangedEventArgs e)
        {
            GpsLabel.Text = String.Format("Latitude {0} Longitude {1} ", e.Latitude, e.Longitude);
            var Radius = MyMap.VisibleRegion.Radius;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(e.Latitude, e.Longitude), Distance.FromKilometers(Radius.Kilometers)));

        }

        private async void GetGPSClicked(object sender, EventArgs e)
        {

            var gpsPos = await gps.GetPositionAsync();
            var Radius = MyMap.VisibleRegion.Radius;
            GpsLabel.Text = String.Format("Latitude {0} Longitude {1} ", gpsPos.Latitude, gpsPos.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(gpsPos.Latitude, gpsPos.Longitude), Distance.FromKilometers(Radius.Kilometers)));

        }
        private async void TrackGPSClicked(object sender, EventArgs e)
        {
            await gps.TrackPositionAsync();
        }
        private async void StopTrackGPsClicked(object sender, EventArgs e)
        {
            await gps.StopTrackPositionAsync();
        }

        private async void StartPosition()
        {
            var gpsPos = await gps.GetPositionAsync();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(gpsPos.Latitude, gpsPos.Longitude), Distance.FromKilometers(1)));

        }
        private static void Calculate(MapSpan region)
        {
            var center = region.Center;

        }
   

    }
}

  
