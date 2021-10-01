using Newtonsoft.Json;
using RestAndJson.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestAndJson.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        //for Location
        private string station;
        public string StationName
        {
            get { return station; }
            set
            {
                station = value;
                NotifyPropertyChanged();
            }
        }
        
        //for elevation
        private string el;
        public string Elevation
        {
            get { return el; }
            set
            {
                el = value;
                NotifyPropertyChanged();
            }
        }
        
        //for temperature
        private string temp;
        public string Temperature
        {
            get { return temp; }
            set
            {
                temp = value;
                NotifyPropertyChanged();
            }
        }
        
        //for humidity
        private string humid;
        public string Humidity
        {
            get { return humid; }
            set
            {
                humid = value;
                NotifyPropertyChanged();
            }
        }

        //for getweather
        public async Task GetWeatherAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var JsonResult = response.Content.ReadAsStringAsync().Result;
            var weather = JsonConvert.DeserializeObject<WeatherResult>(JsonResult);
            SetValues(weather);
        }

        //SetValues method
        private void SetValues(WeatherResult weather)
        {
            var stationName = weather.weatherObservation.stationName;
            var elevation = weather.weatherObservation.elevation;
            var temperature = weather.weatherObservation.temperature;
            var humidity = weather.weatherObservation.humidity;

            StationName = stationName;
            Elevation = elevation.ToString();
            Temperature = temperature.ToString();
            Humidity = humidity.ToString();

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
