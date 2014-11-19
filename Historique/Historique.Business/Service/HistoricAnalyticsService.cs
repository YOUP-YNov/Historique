using System.Collections.Generic;
using System.Configuration;
using Google.Apis.Analytics.v3.Data;
using Historique.Business.ApiGoogleAnalytics;
using Historique.Business.Models;
using Historique.Business.Models.Analytics;
using GA = Historique.Business.ApiGoogleAnalytics.Analytics;

namespace Historique.Business.Mapper
{
    public class HistoricAnalyticsService : IHistoriqueAnalyticsService
    {
        private static readonly string ANALYTICS_PROFILE_ID = ConfigurationManager.AppSettings["analytics_api_profile_id"];

        public IEnumerable<PageVisiteeBll> GetPagesVisiteesBll(string startDate, string endDate)
        {
            var optionalValues = new ReportingHelper.OptionalValues()
            {
                Dimensions = GA.Dimensions.PAGE_PATH,
            };
            string metrics = GA.GetCommaSeparatedMetricsString(GA.Metrics.PAGE_VIEWS, GA.Metrics.TIME_ON_PAGE);

            return PageVisiteeBll.FromAnalyticsData(QueryAnalyticsApi(startDate, endDate, metrics, optionalValues));
        }

        public IEnumerable<DeviceTypeStatRowBll> GetDevicesStats(string startDate, string endDate)
        {
            var optionalValues = new ReportingHelper.OptionalValues()
            {
                Dimensions = GA.Dimensions.OPERATING_SYSTEM,
            };
            string metrics = GA.GetCommaSeparatedMetricsString(GA.Metrics.SESSIONS, GA.Metrics.CONVERSION_RATE);

            return DeviceTypeStatRowBll.FromAnalyticsData(QueryAnalyticsApi(startDate, endDate, metrics, optionalValues));
        }

        public IEnumerable<DeviceCategoryStatRowBll> GetDevicesCategoryStats(string startDate, string endDate)
        {
            var optionalValues = new ReportingHelper.OptionalValues()
            {
                Dimensions = GA.Dimensions.DEVICE_CATEGORY,
            };
            string metrics = GA.GetCommaSeparatedMetricsString(GA.Metrics.SESSIONS, GA.Metrics.CONVERSION_RATE);

            return DeviceCategoryStatRowBll.FromAnalyticsData(QueryAnalyticsApi(startDate, endDate, metrics, optionalValues));
        }

        private GaData QueryAnalyticsApi(string startDate, string endDate, string metrics, ReportingHelper.OptionalValues optionalValues)
        {
            return ReportingHelper.Get(AnalyticsTools.GetAnalyticsService(), ANALYTICS_PROFILE_ID, startDate, endDate, metrics, optionalValues);
        }
    }
}
