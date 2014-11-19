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

        private readonly IHistoriqueAnalyticsService _historiqueAnalyticsService;

        public AnalyticsController()
        {
        }

        public AnalyticsController(IHistoriqueAnalyticsService historiqueAnalyticsService)
        {
            _historiqueAnalyticsService = historiqueAnalyticsService;
        }

        // GET api/analytics/views/pages
        /// <summary>
        /// Retourne le nombre de vues par pages
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("pages")]
        public List<PageVisitee> GetViewsPerPage(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<PageVisiteeBll, PageVisitee>(_historiqueAnalyticsService.GetPagesVisiteesBll(startDate, endDate).ToList());
        }

        // GET api/analytics/views/os
        /// <summary>
        /// Retourne le nombre de vues par OS
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("os")]
        public List<DeviceTypeStatRow> GetViewsPerOs(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<DeviceTypeStatRowBll, DeviceTypeStatRow>(_historiqueAnalyticsService.GetDevicesStats(startDate, endDate).ToList());
        }

        // GET api/analytics/views/deviceCategory
        /// <summary>
        /// Retourne le nombre de vues par catégorie d'appareil
        /// Format de date : yyyy-mm-dd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("deviceCategory")]
        public List<DeviceCategoryStatRow> GetViewsPerDeviceCategory(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<DeviceCategoryStatRowBll, DeviceCategoryStatRow>(_historiqueAnalyticsService.GetDevicesCategoryStats(startDate, endDate).ToList());
        }
    }
}