using Historique.Business.Mapper;
using Historique.Business.Models;
using Historique.Models;
using System.Collections.Generic;
using System.Linq;

namespace Historique.Controllers
{
    public class PagesVisiteesController : AbstractApiController<PageVisitee>
    {

        private readonly IHistoriqueAnalyticService _historiqueAnalyticService;

        public PagesVisiteesController()
        {
        }

        public PagesVisiteesController(IHistoriqueAnalyticService historiqueAnalyticService)
        {
            _historiqueAnalyticService = historiqueAnalyticService;
        }

        // GET api/pagevisitee
        /// <summary>
        /// Retourne toutes les pages visitées
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PageVisitee> Get(string startDate, string endDate)
        {
            return ConverterUtils.ConvertList<PageVisiteeBll, PageVisitee>(_historiqueAnalyticService.GetPagesVisiteesBll(startDate, endDate).ToList());
        }
    }
}