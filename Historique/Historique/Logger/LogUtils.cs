
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Logger;

namespace Historique.Logger
{
    public class LogUtils
    {

        private static string LOGGER_URL = WebConfigurationManager.AppSettings["api_logger_url"];

        private static string APP_NAME = WebConfigurationManager.AppSettings["app_name"];

        private LogUtils()
        {
        }

        public static void LogError(Exception exception, string message)
        {
            new LErreur(exception, APP_NAME, message, exception is Exception ? 10 : 5).Save(LOGGER_URL);
        }
    }
}