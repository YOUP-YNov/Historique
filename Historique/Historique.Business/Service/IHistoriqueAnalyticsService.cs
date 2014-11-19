using System.Collections.Generic;
using Historique.Business.Models;
using Historique.Business.Models.Analytics;

namespace Historique.Business.Mapper
{
    public interface IHistoriqueAnalyticsService
    {
        IEnumerable<PageVisiteeBll> GetPagesVisiteesBll(string startDate, string endDate);

        IEnumerable<DeviceTypeStatRowBll> GetDevicesStats(string startDate, string endDate);

        IEnumerable<DeviceCategoryStatRowBll> GetDevicesCategoryStats(string startDate, string endDate);
    }
}
