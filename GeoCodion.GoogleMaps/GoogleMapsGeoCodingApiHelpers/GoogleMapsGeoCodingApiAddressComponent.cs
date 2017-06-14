using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiAddressComponent
    {
        [JsonProperty(PropertyName = "long_name")]
        public string LongName { get; set; }

        [JsonProperty(PropertyName = "short_name")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "types")]
        public GoogleMapsGeoCodingApiTypeEnum[] Types { get; set; }
    }
}