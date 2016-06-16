using System.Threading.Tasks;
using GeoCodion.Address;
using GeoCodion.Location;

namespace GeoCodion.GeoCoder
{
	public interface IGeoCoder<TAddress> where TAddress : IAddress
	{
        TAddress GeoCode (string rawAddressToGeocode);
		Task<TAddress> GeoCodeAsync (string rawAddressToGeocode);

		TAddress ReverseGeoCode (GeoLocation geolocationToReverseGeocode);
		Task<TAddress> ReverseGeoCodeAsync (GeoLocation geolocationToReverseGeocode);
	}
}

