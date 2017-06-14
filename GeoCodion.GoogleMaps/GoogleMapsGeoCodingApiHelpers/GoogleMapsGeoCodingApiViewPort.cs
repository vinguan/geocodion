using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiViewPort
    {
        [JsonProperty(PropertyName = "northeast")]
        public GoogleMapsGeoCodingApiViewPortNorthEast GoogleMapsGeoCodingApiViewPortNorthEast { get; set; }

        [JsonProperty(PropertyName = "southwest")]
        public GoogleMapsGeoCodingApiViewPortSouthWest GoogleMapsGeoCodingApiViewPortSouthWest { get; set; }
    }
}