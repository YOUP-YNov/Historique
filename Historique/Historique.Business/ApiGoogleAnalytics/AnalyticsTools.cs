using System.Configuration;
using System.Web.Hosting;
using Google.Apis.Analytics.v3;
using System;
using Logger;

namespace Historique.Business.ApiGoogleAnalytics
{
    public static class AnalyticsTools
    {
        private static AnalyticsService _analyticsService;

        private const string ANALYTICS_ACCOUNT_EMAIL_KEY = "analytics_api_account_email";
        private const string ANALYTICS_KEY_FILE_NAME_KEY = "analytics_api_key_file_path";
        private static string urlLogger = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Gets the analytics analyticsService.
        /// </summary>
        /// <returns></returns>
        public static AnalyticsService GetAnalyticsService()
        {
            String ACCOUNT_EMAIL = ConfigurationManager.AppSettings[ANALYTICS_ACCOUNT_EMAIL_KEY];
            String ANALYTICS_KEY_FILE_PATH = ConfigurationManager.AppSettings[ANALYTICS_KEY_FILE_NAME_KEY];

            if (_analyticsService == null)
            {
                try
                {
                    String keyFilename = HostingEnvironment.MapPath("~/App_Data/" + ANALYTICS_KEY_FILE_PATH);

                    _analyticsService = AuthenticationHelper.AuthenticateServiceAccount(ACCOUNT_EMAIL, keyFilename);
                }
                catch (Exception ex)
                {
                    // TODO log exception
                    new LErreur(ex, "Historique.Business", "ApiGoogleAnalytics.AnalyticsTools.GetAnalyticsService").Save(urlLogger);
                }
            }

            return _analyticsService;
        }
    }
}