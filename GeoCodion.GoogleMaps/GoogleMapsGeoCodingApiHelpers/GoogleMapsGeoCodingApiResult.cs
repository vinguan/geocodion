using Newtonsoft.Json;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    public class GoogleMapsGeoCodingApiResult
    {
        [JsonProperty(PropertyName = "formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty(PropertyName = "address_components")]
        public GoogleMapsGeoCodingApiAddressComponent[] GoogleMapsGeoCodingApiAddressComponents { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public GoogleMapsGeoCodingApiGeometry GoogleMapsGeoCodingApiGeometry { get; set; }

        [JsonProperty(PropertyName = "partial_match")]
        public bool? PartialMatch { get; set; }

        [JsonProperty(PropertyName = "place_id")]
        public string PlaceId { get; set; }

        [JsonProperty(PropertyName = "types")]
        public GoogleMapsGeoCodingApiTypeEnum[] Types { get; set; }
    }
}