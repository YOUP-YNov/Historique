using System;
using System.Collections.Generic;
using Google.Apis.Analytics.v3.Data;

namespace Historique.Business.Models.Analytics
{
    public class DeviceCategoryStatRowBll
    {
        public string DeviceCategory { get; set; }

        public int NbViews { get; set; }

        public double ConversionRate { get; set; }

        public static IEnumerable<DeviceCategoryStatRowBll> FromAnalyticsData(GaData analyticsData)
        {
            List<DeviceCategoryStatRowBll> deviceTypeStatsRowBll = new List<DeviceCategoryStatRowBll>();

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

        private static DeviceCategoryStatRowBll FromAnalyticsRowData(IList<String> analyticsRowData)
        {
            return new DeviceCategoryStatRowBll()
            {
                DeviceCategory = analyticsRowData[0],
                NbViews = int.Parse(analyticsRowData[1]),
                ConversionRate = double.Parse(analyticsRowData[2])
            };
        }
    }
}
