using System.Web.Http;
using Historique.Business.Mapper;
using Historique.Business.Models;
using Historique.Business.Models.Analytics;
using Historique.Models;
using System.Collections.Generic;
using System.Linq;
using Historique.Models.Analytics;

namespace Historique.Controllers
{
    [RoutePrefix("api/analytics/views")]
    public class AnalyticsController : AbstractApiController<PageVisitee>
    {

        private readonly IHistoriqueAnalyticService _historiqueAnalyticService;

        public AnalyticsController()
        {
        }

        public AnalyticsController(IHistoriqueAnalyticService historiqueAnalyticService)
        {
            _historiqueAnalyticService = historiqueAnalyticService;
        }

        // GET api/analytics/views/pages
        /// <summary>
        /// Retourne le nombre de vues par pages
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("pages")]
        public IEnumerable<PageVisitee> GetViewsPerPage(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<PageVisiteeBll, PageVisitee>(_historiqueAnalyticService.GetPagesVisiteesBll(startDate, endDate).ToList());
        }

        // GET api/analytics/views/os
        /// <summary>
        /// Retourne le nombre de vues par OS
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("os")]
        public IEnumerable<DeviceTypeStatRow> GetViewsPerOs(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<DeviceTypeStatRowBll, DeviceTypeStatRow>(_historiqueAnalyticService.GetDevicesStats(startDate, endDate).ToList());
        }

        // GET api/analytics/views/deviceCategory
        /// <summary>
        /// Retourne le nombre de vues par catégorie d'appareil
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("deviceCategory")]
        public IEnumerable<DeviceCategoryStatRow> GetViewsPerDeviceCategory(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<DeviceCategoryStatRowBll, DeviceCategoryStatRow>(_historiqueAnalyticService.GetDevicesCategoryStats(startDate, endDate).ToList());
        }
    }
}