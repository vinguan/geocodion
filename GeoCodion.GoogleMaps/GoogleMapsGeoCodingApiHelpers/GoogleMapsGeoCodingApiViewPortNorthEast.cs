using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiViewPortNorthEast
    {
        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Longitude { get; set; }
    }
}