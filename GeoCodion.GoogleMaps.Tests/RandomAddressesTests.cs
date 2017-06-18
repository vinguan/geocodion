using System;
using System.Threading.Tasks;
using GeoCodion.Address;
using GeoCodion.GoogleMaps.Address;
using GeoCodion.GoogleMaps.Exceptions;
using GeoCodion.GoogleMaps.Factories;
using GeoCodion.GoogleMaps.GeoCoder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restion;

namespace GeoCodion.GoogleMaps.Tests
{
    [TestClass]
    public class RandomAddressesTests
    {
        private readonly string _apiKey = "AIzaSyC0Uuho0scMhNjkj3zfuPARVXIaaqLgJBc";

        [TestMethod]
        public async Task ShouldGeocodeARandomBrazilAddress()
        {
            try
            {
                var googleMapsGeoCoder =  GoogleMapsGeoCoderFactory.CreateGoogleMapsGeoCoder(_apiKey);

                IGoogleMapsAddress address = await googleMapsGeoCoder
                                   .ApiKey(_apiKey)
                                   .GeoCodeAsync("Rua ester de lima 150", new GoogleMapsGeoCoderOptions() { MustCacheFullResponse = true });

                Console.WriteLine(address.GeoLocation.Latitude);

                Console.WriteLine(address.GeoLocation.Longitude);

                Console.WriteLine(address.FormattedAddress);
            }
            catch (GoogleMapsGeoCoderException googleMapsGeoCoderException)
            {
                Console.WriteLine(googleMapsGeoCoderException.GoogleMapsGeoCodingApiStatus);

                Assert.Fail(googleMapsGeoCoderException.Message);
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                throw;
            }

        }

        [TestMethod]
        public async Task ShouldReverseGeocodeARandomBrazilAddress()
        {
            try
            {
                var googleMapsGeoCoder = GoogleMapsGeoCoderFactory.CreateGoogleMapsGeoCoder().ApiKey(_apiKey);

                IGoogleMapsAddress address = await googleMapsGeoCoder
                                             .ReverseGeoCodeAsync(new GeoLocation(){Latitude = "-19.8817305", Longitude = "-43.9401788" }, new GoogleMapsGeoCoderOptions() { MustCacheFullResponse = true });

                Console.WriteLine(address.GeoLocation.Latitude);

                Console.WriteLine(address.GeoLocation.Longitude);

                Console.WriteLine(address.FormattedAddress);
            }
            catch (GoogleMapsGeoCoderException googleMapsGeoCoderException)
            {
                Console.WriteLine(googleMapsGeoCoderException.GoogleMapsGeoCodingApiStatus);

                Assert.Fail(googleMapsGeoCoderException.Message);
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                throw;
            }
        }
        [TestMethod]
        public async Task ShouldReverseGeocodeARandomBrazilAddressWithPlaceId()
        {
            try
            {
                var googleMapsGeoCoder = GoogleMapsGeoCoderFactory.CreateGoogleMapsGeoCoder().ApiKey(_apiKey);

                IGoogleMapsAddress address = await googleMapsGeoCoder
                    .ReverseGeoCodeAsync("ChIJlaRK3nmapgARXzPX-2Ksopg", new GoogleMapsGeoCoderOptions() { MustCacheFullResponse = true });

                Console.WriteLine(address.GeoLocation.Latitude);

                Console.WriteLine(address.GeoLocation.Longitude);

                Console.WriteLine(address.FormattedAddress);
            }
            catch (GoogleMapsGeoCoderException googleMapsGeoCoderException)
            {
                Console.WriteLine(googleMapsGeoCoderException.GoogleMapsGeoCodingApiStatus);

                Assert.Fail(googleMapsGeoCoderException.Message);
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                throw;
            }
        }
    }
}
