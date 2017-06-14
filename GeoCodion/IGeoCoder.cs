using System.Threading.Tasks;
using GeoCodion.Address;

namespace GeoCodion
{
    public interface IGeoCoder
    {
        Task<IAddress> GeoCodeAsync(string rawAddressToGeocode);

        Task<IAddress> ReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode);
    }
}

