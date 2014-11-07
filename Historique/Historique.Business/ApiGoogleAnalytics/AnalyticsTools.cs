using Google.Apis.Analytics.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historique.Business.ApiGoogleAnalytics
{
    public static class AnalyticsTools
    {

        /// <summary>
        /// Gets the analytics service.
        /// </summary>
        /// <returns></returns>
        public static AnalyticsService GetAnalyticsService()
        {
            AnalyticsService service = null;
            // Authenticate Oauth2
            String CLIENT_ID = "28022356798-vpb9qu02cgbq8ef0d0l2p55teg4v865m.apps.googleusercontent.com";
            String CLIENT_SECRET = "5xwQnF_7mao02bux4F8Tstmg";

            try
            {
                service = AuthenticationHelper.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, "projetingesupaspdotnet2014@gmail.com");
            }
            catch(Exception ex)
            {

            }

            return service;
        }
    }
}
