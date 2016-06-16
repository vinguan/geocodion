using GeoCodion.Location;

namespace GeoCodion.Address
{
	/// <summary>
	/// Address.
	/// </summary>
	public interface IAddress
	{
		string Street { get; }

		string Number { get; }

		string Neighborhood { get; }

        string District { get; }

		string PostalCode { get; }

		string City { get; }

		string State { get; }

		string Country { get; }

		string Continent { get; }

        GeoLocation GeoLocation { get; }
	}
}

