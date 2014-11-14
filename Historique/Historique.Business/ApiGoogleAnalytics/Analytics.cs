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

            public const string PAGE_PATH = "ga:pagePath";

        }

        public class Metrics
        {
            private Metrics()
            {
            }

            public const string PAGE_VIEWS = "ga:pageviews";
            public const string TIME_ON_PAGE = "ga:timeOnPage";
        }

        public static string GetCommaSeparatedMetricsString(params string[] metadatas)
        {
            return String.Join(",", metadatas);
        }
    }
}
