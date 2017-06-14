using GeoCodion.Address;

namespace GeoCodion.GoogleMaps.Address
{
    public interface IGoogleMapsAddress : IAddress
    {
        string FormattedAddress { get; }
    }
}