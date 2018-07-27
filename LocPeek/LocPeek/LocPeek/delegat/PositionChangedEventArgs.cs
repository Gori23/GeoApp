using System;
using System.Collections.Generic;
using System.Text;

namespace LocPeek.delegat
{
    public class PositionChangedEventArgs:EventArgs
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
