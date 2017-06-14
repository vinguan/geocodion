namespace GeoCodion.Address
{
	/// <summary>
	/// Address.
	/// </summary>
	public interface IAddress
	{
	    GeoLocation GeoLocation { get; }

        string PostalCode { get; }

	    string Number { get; }

        Street Street { get; }

	    Neighborhood Neighborhood { get; }

	    City City { get; }

        District District { get; }

	    State State { get; }

	    Country Country { get; }

	    Continent Continent { get; }
	}
}

