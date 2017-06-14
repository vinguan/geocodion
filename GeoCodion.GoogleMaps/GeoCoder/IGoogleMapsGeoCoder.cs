using System.Threading.Tasks;
using GeoCodion.Address;
using GeoCodion.GoogleMaps.Address;
using GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers;

namespace GeoCodion.GoogleMaps.GeoCoder
{
    public interface IGoogleMapsGeoCoder 
    {
        IGoogleMapsGeoCoderApiKeySettedUp ApiKey(string apiKey);
    }

    public interface IGoogleMapsGeoCoderApiKeySettedUp : IGeoCoder
    {
        /// <summary>
        /// Gets the last response from the Google Maps Geocoding api cached allowed through <see cref="GoogleMapsGeoCoderOptions"/>
        /// </summary>
        GoogleMapsGeoCodingApiResponse GoogleMapsGeoCodingApiResponse { get; }

        Task<IGoogleMapsAddress> GeoCodeAsync(string rawAddressToGeocode, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions);

        Task<IGoogleMapsAddress> ReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions);

        Task<IGoogleMapsAddress> ReverseGeoCodeAsync(string placeId, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions);
    }
}