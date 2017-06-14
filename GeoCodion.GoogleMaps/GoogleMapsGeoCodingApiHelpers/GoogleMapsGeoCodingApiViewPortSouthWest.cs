using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiViewPortSouthWest 
    {
        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Longitude { get; set; }
    }
}