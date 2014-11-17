using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historique.Models.Analytics
{
    public class DeviceCategoryStatRow
    {
        public string DeviceCategory { get; set; }

        public int NbViews { get; set; }

        public double ConversionRate { get; set; }
    }
}