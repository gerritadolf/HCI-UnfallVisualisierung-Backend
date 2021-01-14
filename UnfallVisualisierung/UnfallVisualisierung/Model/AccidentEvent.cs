using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model
{
    public class AccidentEvent
    {
        public string ID { get; set; }
        public string Source { get; set; }
        public float TMC { get; set; }
        public int Serverity { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public float Start_Lat { get; set; }
        public float Start_Lng { get; set; }
        public float End_Lat { get; set; }
        public float End_Lng {get; set;}
        public double Distance { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Side { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string Airport_Code { get; set; }
        public DateTime Weather_Timestamp { get; set; }
        public double Temperature { get; set; }
        public double Wind_Chill { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double Visibility { get; set; }
        public string Wind_Direction { get; set; }
        public string Wind_Speed { get; set; }
        public double Precipitation { get; set; }
        public string Weather_Condition { get; set; }
        public string WeatherGroupName { get; set; }
        public bool Amenity { get; set; }
        public bool Bump { get; set; }
        public bool Crossing { get; set; }
        public bool Give_Way { get; set; }
        public bool Junction { get; set; }
        public bool No_Exit { get; set; }
        public bool Railway { get; set; }
        public bool Roundabout { get; set; }
        public bool Station { get; set; }
        public bool Stop { get; set; }
        public bool Traffic_Calming { get; set; }
        public bool Traffic_Signal { get; set; }
        public bool Turning_Loop { get; set; }
        public string Sunrise_Sunset { get; set; }
        public string Civil_Twilight { get; set; }
        public string Nautical_Twilight { get; set; }
        public string Astronomical_Twilight { get; set; }
}
}
