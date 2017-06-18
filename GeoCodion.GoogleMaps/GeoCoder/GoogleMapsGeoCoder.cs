using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GeoCodion.Address;
using GeoCodion.GoogleMaps.Address;
using GeoCodion.GoogleMaps.Exceptions;
using GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers;
using Restion;

namespace GeoCodion.GoogleMaps.GeoCoder
{
    internal class GoogleMapsGeoCoder : IGoogleMapsGeoCoder, IGoogleMapsGeoCoderApiKeySettedUp
    {
        //Fields
        private IRestionClient _restionClient;
        private string _apiKey;

       //Properties
        public GoogleMapsGeoCodingApiResponse GoogleMapsGeoCodingApiResponse { get; private set; }

        //Constructors
        internal GoogleMapsGeoCoder()
        {
            if (_restionClient == null)
                _restionClient = new RestionClient(GoogleMapsGeoCodingApiConstants.GoogleMapsGeoCodingApiUrl);
        }

        internal GoogleMapsGeoCoder(string apiKey)
        {
            if (_restionClient == null)
                _restionClient = new RestionClient(GoogleMapsGeoCodingApiConstants.GoogleMapsGeoCodingApiUrl);

            _apiKey = apiKey;
        }

        //Methods

        //Private Methods
        private async Task<GoogleMapsGeoCodingApiResponse> RequestGoogleMapsGeoCodeApi(string rawAddressToGeocode)
        {
            var googleMapsGeoCodeRestionRequest = new RestionRequest()
                                                  .WithHttpMethod(HttpMethod.Get)
                                                  .AddParameter("address", rawAddressToGeocode)
                                                  .AddParameter("key", _apiKey);

            var googleMapsGeoCodeRestionResponse = await _restionClient.ExecuteRequestAsync<GoogleMapsGeoCodingApiResponse>(googleMapsGeoCodeRestionRequest);

            if (googleMapsGeoCodeRestionResponse.Exception != null)
                throw googleMapsGeoCodeRestionResponse.Exception;

            if (googleMapsGeoCodeRestionResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return googleMapsGeoCodeRestionResponse.Content;
            }

            return null;
        }

        private async Task<GoogleMapsGeoCodingApiResponse> RequestGoogleMapsReverseGeoCodeApi(GeoLocation geolocationToReverseGeocode, string placeId)
        {
            var googleMapsGeoCodeRestionRequest = new RestionRequest().WithHttpMethod(HttpMethod.Get).AddParameter("key", _apiKey);

            if (geolocationToReverseGeocode != null)
            {
                googleMapsGeoCodeRestionRequest.AddParameter("latlng", geolocationToReverseGeocode.Latitude + "," + geolocationToReverseGeocode.Longitude);
            }
            else
            {
                googleMapsGeoCodeRestionRequest.AddParameter("place_id", placeId);
            }
                            
            var googleMapsReverseGeoCodeRestionResponse = await _restionClient.ExecuteRequestAsync<GoogleMapsGeoCodingApiResponse>(googleMapsGeoCodeRestionRequest);

            if (googleMapsReverseGeoCodeRestionResponse.Exception != null)
                throw googleMapsReverseGeoCodeRestionResponse.Exception;

            if (googleMapsReverseGeoCodeRestionResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return googleMapsReverseGeoCodeRestionResponse.Content;
            }

            return null;
        }

        private GoogleMapsAddress ConvertGoogleMapsGeoCodeResultToGoogleMapsAddress(GoogleMapsGeoCodingApiResult googleMapsGeoCodingApiResult)
        {
            var googleMapsAddress = new GoogleMapsAddress();

            //GeoLocation
            googleMapsAddress.GeoLocation = new GeoLocation()
            {
                Latitude = googleMapsGeoCodingApiResult.GoogleMapsGeoCodingApiGeometry.GoogleMapsGeoCodingApiLocation.Latitude,
                Longitude = googleMapsGeoCodingApiResult.GoogleMapsGeoCodingApiGeometry.GoogleMapsGeoCodingApiLocation.Longitude
            };

            //Formatted address
            googleMapsAddress.FormattedAddress = googleMapsGeoCodingApiResult.FormattedAddress;

            foreach (var googleMapsGeoCodeAddressComponent in googleMapsGeoCodingApiResult.GoogleMapsGeoCodingApiAddressComponents)
            {
                if (googleMapsGeoCodeAddressComponent.Types != null)
                {
                    //PostalCode
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.PostalCode))
                    {
                        googleMapsAddress.PostalCode = googleMapsGeoCodeAddressComponent.LongName;
                    }

                    //Number
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.StreetNumber))
                    {
                        googleMapsAddress.Number = googleMapsGeoCodeAddressComponent.LongName;
                    }

                    //Street
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.StreetAddress) ||
                        googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.Route))
                    {
                        if (googleMapsAddress.Street == null)
                            googleMapsAddress.Street = new Street();

                        googleMapsAddress.Street.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.Street.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }

                    //Neighborhood
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.Sublocality))
                    {
                        if (googleMapsAddress.Neighborhood == null)
                            googleMapsAddress.Neighborhood = new Neighborhood();

                        googleMapsAddress.Neighborhood.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.Neighborhood.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }

                    //City
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.Locality) ||
                        googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.AdministrativeAreaLevel2))
                    {
                        if (googleMapsAddress.City == null)
                            googleMapsAddress.City = new City();

                        googleMapsAddress.City.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.City.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }

                    //District
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.AdministrativeAreaLevel2))
                    {
                        if (googleMapsAddress.District == null)
                            googleMapsAddress.District = new District();

                        googleMapsAddress.District.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.District.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }

                    //State
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.AdministrativeAreaLevel1))
                    {
                        if (googleMapsAddress.State == null)
                            googleMapsAddress.State = new State();

                        googleMapsAddress.State.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.State.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }

                    //Country
                    if (googleMapsGeoCodeAddressComponent.Types.Contains(GoogleMapsGeoCodingApiTypeEnum.Country))
                    {
                        if (googleMapsAddress.Country == null)
                            googleMapsAddress.Country = new Country();

                        googleMapsAddress.Country.FullName = googleMapsGeoCodeAddressComponent.LongName;
                        googleMapsAddress.Country.Abbreviation = googleMapsGeoCodeAddressComponent.ShortName;
                    }
                }
            }

            return googleMapsAddress;
        }

        private IGoogleMapsAddress HandleGoogleMapsGeoCodingApiResponse(GoogleMapsGeoCodingApiResponse googleMapsGeoCodingApiResponse, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions)
        {
            if (googleMapsGeoCodingApiResponse.Status == GoogleMapsGeoCodingApiStatus.Ok)
            {
                if (googleMapsGeoCoderOptions != null && googleMapsGeoCoderOptions.MustCacheFullResponse)
                {
                    GoogleMapsGeoCodingApiResponse = googleMapsGeoCodingApiResponse;
                }

                var googleMapsAddress = ConvertGoogleMapsGeoCodeResultToGoogleMapsAddress(googleMapsGeoCodingApiResponse.GoogleMapsGeoCodingApiResults[0]);

                return googleMapsAddress;
            }

            throw new GoogleMapsGeoCoderException(googleMapsGeoCodingApiResponse.Status, "An error occured when trying to GeoCode, check your api and the input passed", null);
        }

        private async Task<GoogleMapsGeoCodingApiResponse> InternalGeoCodeAsync(string rawAddressToGeoCode)
        {
            if (string.IsNullOrWhiteSpace(rawAddressToGeoCode))
                throw new ArgumentNullException(nameof(rawAddressToGeoCode));

            var googleMapsGeoCodeResponse = await RequestGoogleMapsGeoCodeApi(rawAddressToGeoCode);

            return googleMapsGeoCodeResponse;
        }

        private async Task<GoogleMapsGeoCodingApiResponse> InternalReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode)
        {
            if (geolocationToReverseGeocode == null)
                throw new ArgumentNullException(nameof(geolocationToReverseGeocode));

            if (string.IsNullOrWhiteSpace(geolocationToReverseGeocode.Longitude))
                throw new ArgumentException("Longitude");

            if (string.IsNullOrWhiteSpace(geolocationToReverseGeocode.Latitude))
                throw new ArgumentException("Latitude");

            var googleMapsGeoCodeResponse = await RequestGoogleMapsReverseGeoCodeApi(geolocationToReverseGeocode, null);

            return googleMapsGeoCodeResponse;
        }

        private async Task<GoogleMapsGeoCodingApiResponse> InternalReverseGeoCodeAsync(string placeId)
        {
            if (string.IsNullOrWhiteSpace(placeId))
                throw new ArgumentNullException(nameof(placeId));

            var googleMapsGeoCodeResponse = await RequestGoogleMapsReverseGeoCodeApi(null, placeId);

            return googleMapsGeoCodeResponse;
        }


        //Public Methods
        public IGoogleMapsGeoCoderApiKeySettedUp ApiKey(string apiKey)
        {
            _apiKey = apiKey;

            return this;
        }

        public async Task<IGoogleMapsAddress> GeoCodeAsync(string rawAddressToGeocode, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions)
        {
            try
            {
                var googleMapsGeoCodingApiResponse = await InternalGeoCodeAsync(rawAddressToGeocode);

                return HandleGoogleMapsGeoCodingApiResponse(googleMapsGeoCodingApiResponse, googleMapsGeoCoderOptions);
            }
            catch (GoogleMapsGeoCoderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GoogleMapsGeoCoderException("An error occured when trying to GeoCode, please check InnerException", ex);
            }
        }

        public async Task<IAddress> GeoCodeAsync(string rawAddressToGeocode)
        {
            return await GeoCodeAsync(rawAddressToGeocode, null);
        }

        public async Task<IGoogleMapsAddress> ReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode, GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions)
        {
            try
            {
                var googleMapsGeoCodingApiResponse = await InternalReverseGeoCodeAsync(geolocationToReverseGeocode);

                return HandleGoogleMapsGeoCodingApiResponse(googleMapsGeoCodingApiResponse, googleMapsGeoCoderOptions);
            }
            catch (GoogleMapsGeoCoderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GoogleMapsGeoCoderException("An error occured when trying to GeoCode, please check InnerException", ex);
            }
        }

        public async Task<IAddress> ReverseGeoCodeAsync(GeoLocation geolocationToReverseGeocode)
        {
            return await ReverseGeoCodeAsync(geolocationToReverseGeocode, null);
        }

        public async Task<IGoogleMapsAddress> ReverseGeoCodeAsync(string placeId,
            GoogleMapsGeoCoderOptions googleMapsGeoCoderOptions)
        {
            try
            {
                var googleMapsGeoCodingApiResponse = await InternalReverseGeoCodeAsync(placeId);

                return HandleGoogleMapsGeoCodingApiResponse(googleMapsGeoCodingApiResponse, googleMapsGeoCoderOptions);
            }
            catch (GoogleMapsGeoCoderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GoogleMapsGeoCoderException(
                    "An error occured when trying to GeoCode, please check InnerException", ex);
            }
        }
    }
}