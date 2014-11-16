using System;
using System.Collections.Generic;
using Google.Apis.Analytics.v3.Data;

namespace Historique.Business.Models
{
    public class PageVisiteeBll
    {
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private int _NbVue;

        public int NbVue
        {
            get { return _NbVue; }
            set { _NbVue = value; }
        }

        private double _TempsMoyen;

        public double TempsMoyen
        {
            get { return _TempsMoyen; }
            set { _TempsMoyen = value; }
        }

        public static IEnumerable<PageVisiteeBll> FromAnalyticsData(GaData analyticsData)
        {
            List<PageVisiteeBll> pageVisiteesBll = new List<PageVisiteeBll>();

            if (analyticsData != null)
            {
                if (analyticsData.Rows != null && analyticsData.Rows.Count > 0)
                {
                    foreach (var row in analyticsData.Rows)
                    {
                        pageVisiteesBll.Add(FromAnalyticsRowData(row));
                    }
                }
            }

            return pageVisiteesBll;
        }

        private static PageVisiteeBll FromAnalyticsRowData(IList<String> analyticsRowData)
        {
            return new PageVisiteeBll()
            {
                Nom = analyticsRowData[0],
                NbVue = int.Parse(analyticsRowData[1]),
                TempsMoyen = double.Parse(analyticsRowData[2])
            };
        }
    }
}
