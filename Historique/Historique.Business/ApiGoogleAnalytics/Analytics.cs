using System;

namespace Historique.Business.ApiGoogleAnalytics
{

    class Analytics
    {
        private Analytics()
        {
        }

        public class Dimensions
        {
            private Dimensions()
            {
            }

            public static readonly string PAGE_PATH = "ga:pagePath";
            public static readonly string OPERATING_SYSTEM = "ga:operatingSystem";
            public static readonly string DEVICE_CATEGORY = "ga:deviceCategory";
        }

        public class Metrics
        {
            private Metrics()
            {
            }

            public static readonly string PAGE_VIEWS = "ga:pageviews";
            public static readonly string TIME_ON_PAGE = "ga:timeOnPage";
            public static readonly string SESSIONS = "ga:sessions";
            public static readonly string CONVERSION_RATE = "ga:goalConversionRateAll";
        }

        public static string GetCommaSeparatedMetricsString(params string[] metadatas)
        {
            return String.Join(",", metadatas);
        }
    }
}
