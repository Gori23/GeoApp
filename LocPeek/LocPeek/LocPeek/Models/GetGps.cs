using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LocPeek.delegat;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

namespace LocPeek.Models
{
    class GetGps
    {
        //public PositionChangedDelegate PositionChangedDelegate;
        public EventHandler<PositionChangedEventArgs> PositionChangedEventArgs;

        public async Task<Plugin.Geolocator.Abstractions.Position> GetPositionAsync()
        {
            CrossGeolocator.Current.DesiredAccuracy = 10;
            return await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(100));
        }

        public async Task TrackPositionAsync()
        {
            if (CrossGeolocator.Current.IsListening)
            {
                return;
            }
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromMilliseconds(1000), 1);
            CrossGeolocator.Current.PositionChanged += PositionChanged;
            CrossGeolocator.Current.PositionError += PostionError;
        }

        private void PostionError(object sender, PositionErrorEventArgs e)
        {

        }

        public void PositionChanged(object sender, PositionEventArgs e)
        {
            PositionChangedEventArgs(this, new PositionChangedEventArgs() {Latitude=e.Position.Latitude,Longitude=e.Position.Longitude});
        }

        public async Task StopTrackPositionAsync()
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                return;
            }
            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= PositionChanged;
            CrossGeolocator.Current.PositionError -= PostionError;
        }

    }
}
