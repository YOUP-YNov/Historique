using System;
using System.Collections.Generic;
using Google.Apis.Analytics.v3.Data;

namespace Historique.Business.Models.Analytics
{
    public class DeviceTypeStatRowBll
    {
        public string OsType { get; set; }

        public int NbViews { get; set; }

        public double ConversionRate { get; set; }

        public static IEnumerable<DeviceTypeStatRowBll> FromAnalyticsData(GaData analyticsData)
        {
            List<DeviceTypeStatRowBll> deviceTypeStatsRowBll = new List<DeviceTypeStatRowBll>();

            if (analyticsData != null)
            {
                if (analyticsData.Rows != null && analyticsData.Rows.Count > 0)
                {
                    foreach (var row in analyticsData.Rows)
                    {
                        deviceTypeStatsRowBll.Add(FromAnalyticsRowData(row));
                    }
                }
            }

            return deviceTypeStatsRowBll;
        }

        private static DeviceTypeStatRowBll FromAnalyticsRowData(IList<String> analyticsRowData)
        {
            return new DeviceTypeStatRowBll()
            {
                OsType = analyticsRowData[0],
                NbViews = int.Parse(analyticsRowData[1]),
                ConversionRate = double.Parse(analyticsRowData[2])
            };
        }
    }
}
