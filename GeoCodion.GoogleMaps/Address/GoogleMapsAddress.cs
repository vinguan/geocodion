using GeoCodion.Address;

namespace GeoCodion.GoogleMaps.Address
{
    internal class GoogleMapsAddress : IGoogleMapsAddress
    {
        #region Properties

        #region Public Properties
        public string PostalCode { get; set; }
        public string Number { get; set; }
        public Street Street { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public District District { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public Continent Continent { get; set; }
        public GeoLocation GeoLocation { get; set; }

        public string FormattedAddress { get; set; }

        #endregion Public Properties

        #endregion Properties

        #region Constructors

        #region Public Constructors

        public GoogleMapsAddress()
        {

        }

        #endregion Public Constructors

        #endregion Constructors
    }
}