using System;
using GeoCodion.GoogleMaps.GoogleMapsGeoCodingApiHelpers;

namespace GeoCodion.GoogleMaps.Exceptions
{
    /// <summary>
    /// Represents the GoogleMapsGeoCoderException
    /// </summary>
    public class GoogleMapsGeoCoderException : Exception
    {
        /// <summary>
        /// Gets the GoogleMapsGeoCodingApiStatus
        /// </summary>
        public GoogleMapsGeoCodingApiStatus GoogleMapsGeoCodingApiStatus { get; }


        internal GoogleMapsGeoCoderException(GoogleMapsGeoCodingApiStatus googleMapsGeoCodingApiStatus, string message, Exception innerException) : base(message, innerException)
        {
            GoogleMapsGeoCodingApiStatus = googleMapsGeoCodingApiStatus;
        }

        internal GoogleMapsGeoCoderException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}