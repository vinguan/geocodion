namespace GeoCodion.Address
{
	/// <summary>
	/// Address.
	/// </summary>
	public interface IAddress
	{
        /// <summary>
        /// Gets the GeoLocation
        /// </summary>
	    GeoLocation GeoLocation { get; }

        /// <summary>
        /// Gets the PostalCode
        /// </summary>
        string PostalCode { get; }

        /// <summary>
        /// Gets the Number
        /// </summary>
        string Number { get; }

        /// <summary>
        /// Gets the Street
        /// </summary>
        Street Street { get; }

        /// <summary>
        /// Gets the Neighborhood
        /// </summary>
        Neighborhood Neighborhood { get; }

        /// <summary>
        /// Gets the City
        /// </summary>
        City City { get; }

        /// <summary>
        /// Gets the District
        /// </summary>
        District District { get; }

        /// <summary>
        /// Gets the State
        /// </summary>
        State State { get; }

        /// <summary>
        /// Gets the Country
        /// </summary>
        Country Country { get; }

        /// <summary>
        /// Gets the Continent
        /// </summary>
        Continent Continent { get; }
	}
}

