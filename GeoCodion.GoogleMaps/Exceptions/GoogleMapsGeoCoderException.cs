using System;
using GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers;

namespace GeoCodion.GoogleMaps.Exceptions
{
    public class GoogleMapsGeoCoderException : Exception
    {
        public GoogleMapsGeoCodingApiStatus GoogleMapsGeoCodingApiStatus { get; }

        public GoogleMapsGeoCoderException(GoogleMapsGeoCodingApiStatus googleMapsGeoCodingApiStatus, string message, Exception innerException) : base(message, innerException)
        {
            GoogleMapsGeoCodingApiStatus = googleMapsGeoCodingApiStatus;
        }

        public GoogleMapsGeoCoderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}