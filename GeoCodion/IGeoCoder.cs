using System.Threading.Tasks;
using GeoCodion.Address;

namespace GeoCodion
{
    /// <summary>
    /// Represents the IGeoCoder
    /// </summary>
    public interface IGeoCoder
    {
        /// <summary>
        /// Geocode a address async
        /// </summary>
        /// <param name="rawAddressToGeocode">rawAddress</param>
        /// <returns>The <see cref="IAddress"/> geocoded</returns>
        Task<IAddress> GeoCodeAsync(string rawAddressToGeocode);

        /// <summary>
        /// Reverse Geocode a address async
        /// </summary>
        /// <param name="geolocationToReverseGeocode">rawAddress</param>
        /// <returns>The <see cref="IAddress"/> geocoded</returns>
        Task<IAddress> ReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode);
    }
}

