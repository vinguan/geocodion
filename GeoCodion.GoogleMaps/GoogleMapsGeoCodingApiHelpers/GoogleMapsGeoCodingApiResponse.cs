using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiResponse
    {
        [JsonProperty(PropertyName = "results")]
        public GoogleMapsGeoCodingApiResult[] GoogleMapsGeoCodingApiResults { get; set; }

        [JsonProperty(PropertyName = "status")]
        public GoogleMapsGeoCodingApiStatus Status { get; set; }
    }
}