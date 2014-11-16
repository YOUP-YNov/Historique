using System.Collections.Generic;
using System.Configuration;
using Google.Apis.Analytics.v3.Data;
using Historique.Business.ApiGoogleAnalytics;
using Historique.Business.Models;
using GA = Historique.Business.ApiGoogleAnalytics.Analytics;

namespace Historique.Business.Mapper
{
    public class HistoricAnalyticService : IHistoriqueAnalyticService
    {
        private static readonly string ANALYTICS_PROFILE_ID = ConfigurationManager.AppSettings["analytics_api_profile_id"];

        public IEnumerable<PageVisiteeBll> GetPagesVisiteesBll(string startDate, string endDate)
        {
            var pagesVisiteesBll = new List<PageVisiteeBll>();

            var optionalValues = new ReportingHelper.OptionalValues()
            {
                Dimensions = GA.Dimensions.PAGE_PATH,
            };
            string metrics = GA.GetCommaSeparatedMetricsString(GA.Metrics.PAGE_VIEWS, GA.Metrics.TIME_ON_PAGE);

            GaData gaData = ReportingHelper.Get(AnalyticsTools.GetAnalyticsService(), ANALYTICS_PROFILE_ID, startDate, endDate, metrics, optionalValues);

            return PageVisiteeBll.FromAnalyticsData(gaData);
        }
    }
}
