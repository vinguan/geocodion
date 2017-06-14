using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiGeometry
    {
        [JsonProperty(PropertyName = "location_type")]
        public GoogleMapsGeoCodingApiLocationTypeEnum GoogleMapsGeoCodingApiLocationType { get; set; }

        [JsonProperty(PropertyName = "location")]
        public GoogleMapsGeoCodingApiLocation GoogleMapsGeoCodingApiLocation { get; set; }

        [JsonProperty(PropertyName = "viewport")]
        private GoogleMapsGeoCodingApiViewPort GoogleMapsGeoCodingApiViewPort { get; set; }
    }
}