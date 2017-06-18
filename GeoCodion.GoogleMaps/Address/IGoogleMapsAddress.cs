using GeoCodion.Address;

namespace GeoCodion.GoogleMaps.Address
{
    /// <summary>
    /// Represents the GoogleMapsAddress
    /// </summary>
    public interface IGoogleMapsAddress : IAddress
    {
        /// <summary>
        /// Googles formatted address
        /// </summary>
        string FormattedAddress { get; }
    }
}