using GeoCodion.Address;

namespace GeoCodion.GoogleMaps.Address
{
    internal class GoogleMapsAddress : IGoogleMapsAddress
    {
        //Properties

        /// <inheritdoc />
        public string PostalCode { get; set; }

        /// <inheritdoc />
        public string Number { get; set; }

        /// <inheritdoc />
        public Street Street { get; set; }

        /// <inheritdoc />
        public Neighborhood Neighborhood { get; set; }

        /// <inheritdoc />
        public District District { get; set; }

        /// <inheritdoc />
        public City City { get; set; }

        /// <inheritdoc />
        public State State { get; set; }

        /// <inheritdoc />
        public Country Country { get; set; }

        /// <inheritdoc />
        public Continent Continent { get; set; }

        /// <inheritdoc />
        public GeoLocation GeoLocation { get; set; }

        /// <summary>
        /// Googles formatted address
        /// </summary>
        public string FormattedAddress { get; set; }

        //Constructors
        public GoogleMapsAddress()
        {

        }
    }
}