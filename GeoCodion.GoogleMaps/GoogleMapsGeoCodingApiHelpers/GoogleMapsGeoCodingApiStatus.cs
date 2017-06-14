using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GoogleMapsGeoCodingApiStatus
    {
        [EnumMember(Value = "OK")]
        Ok,
        [EnumMember(Value = "ZERO_RESULTS")]
        ZeroResults,
        [EnumMember(Value = "OVER_QUERY_LIMIT")]
        OverQueryLimit,
        [EnumMember(Value = "REQUEST_DENIED")]
        RequestDenied,
        [EnumMember(Value = "INVALID_REQUEST")]
        InvalidRequest,
        [EnumMember(Value = "UNKNOWN_ERROR")]
        UnknownError
    }
}