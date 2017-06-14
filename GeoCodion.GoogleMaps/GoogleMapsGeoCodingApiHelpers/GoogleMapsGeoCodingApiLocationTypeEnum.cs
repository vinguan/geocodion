using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GoogleMapsGeoCodingApiLocationTypeEnum
    {
        [EnumMember(Value = "ROOFTOP")]
        Rooftop,
        [EnumMember(Value = "RANGE_INTERPOLATED")]
        RangeInterpolated,
        [EnumMember(Value = "GEOMETRIC_CENTER")]
        GeometricCenter,
        [EnumMember(Value = "APPROXIMATE")]
        Approximate,
    }
}