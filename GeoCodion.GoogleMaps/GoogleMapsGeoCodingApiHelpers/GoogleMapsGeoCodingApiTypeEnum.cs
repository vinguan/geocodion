using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GoogleMapsGeoCodingApiTypeEnum
    {
        [EnumMember(Value = "street_address")]
        StreetAddress,
        [EnumMember(Value = "route")]
        Route,
        [EnumMember(Value = "intersection")]
        Intersection,
        [EnumMember(Value = "political")]
        Political,
        [EnumMember(Value = "Country")]
        Country,
        [EnumMember(Value = "administrative_area_level_1")]
        AdministrativeAreaLevel1,
        [EnumMember(Value = "administrative_area_level_2")]
        AdministrativeAreaLevel2,
        [EnumMember(Value = "administrative_area_level_3")]
        AdministrativeAreaLevel3,
        [EnumMember(Value = "administrative_area_level_4")]
        AdministrativeAreaLevel4,
        [EnumMember(Value = "administrative_area_level_5")]
        AdministrativeAreaLevel5,
        [EnumMember(Value = "colloquial_area")]
        ColloquialArea,
        [EnumMember(Value = "locality")]
        Locality,
        [EnumMember(Value = "ward")]
        Ward,
        [EnumMember(Value = "sublocality")]
        Sublocality,
        [EnumMember(Value = "sublocality_level_1")]
        SublocalityLevel1,
        [EnumMember(Value = "sublocality_level_2")]
        SublocalityLevel2,
        [EnumMember(Value = "sublocality_level_3")]
        SublocalityLevel3,
        [EnumMember(Value = "sublocality_level_4")]
        SublocalityLevel4,
        [EnumMember(Value = "sublocality_level_5")]
        SublocalityLevel5,
        [EnumMember(Value = "Neighborhood")]
        Neighborhood,
        [EnumMember(Value = "premise")]
        Premise,
        [EnumMember(Value = "postal_code")]
        PostalCode,
        [EnumMember(Value = "postal_code_prefix")]
        PostalCodePrefix,
        [EnumMember(Value = "natural_feature")]
        NaturalFeature,
        [EnumMember(Value = "airport")]
        Airport,
        [EnumMember(Value = "park")]
        Park,
        [EnumMember(Value = "point_of_interest")]
        PointOfInterest,
        [EnumMember(Value = "floor")]
        Floor,
        [EnumMember(Value = "establishment")]
        Establishment,
        [EnumMember(Value = "parking")]
        Parking,
        [EnumMember(Value = "post_box")]
        PostBox,
        [EnumMember(Value = "postal_town")]
        PostalTown,
        [EnumMember(Value = "room")]
        Room,
        [EnumMember(Value = "street_number")]
        StreetNumber,
        [EnumMember(Value = "bus_station")]
        BusStation,
        [EnumMember(Value = "train_station")]
        TrainStation,
        [EnumMember(Value = "transit_station")]
        TransitStation,
    }
}
