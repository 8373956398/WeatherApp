using System;
using System.Collections.Generic;
using System.Text;

namespace RestAndJson.Model
{
    public class WeatherObservation
    {
        public string weatherCondition { get; set; }
        public string ICAO { get; set; }
        public long elevation { get; set; }
        public string countryCode { get; set; }
        public string cloudsCode { get; set; }
        public long lng { get; set; }
        public long temperature { get; set; }
        public long dewPoint { get; set; }
        public long windSpeed { get; set; }
        public long humidity { get; set; }
        public string stationName { get; set; }
        public DateTime datetime { get; set; }
        public long lat { get; set; }
        public long hectoPascAltimeter { get; set; }
        public string observation { get; set; }
        public long windDirection { get; set; }
        public string clouds { get; set; }
    }
}
