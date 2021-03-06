﻿using GeoCodion.GoogleMaps.GeoCoder;

namespace GeoCodion.GoogleMaps.Factories
{
    public static class GoogleMapsGeoCoderFactory
    {
        public static IGoogleMapsGeoCoder CreateGoogleMapsGeoCoder()
        {
            return new GoogleMapsGeoCoder();
        }

        public static IGoogleMapsGeoCoder CreateGoogleMapsGeoCoder(string apiKey)
        {
            return new GoogleMapsGeoCoder(apiKey);
        }
    }
}