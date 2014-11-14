using Historique.Business.Mapper;
using Historique.Business.Models;
using Historique.Mapper;
using Historique.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Historique.Controllers
{
    public class PagesVisiteesController : ApiController
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
        public IEnumerable<PageVisitee> Get()
        {
            // TODO retrieve startDate + endDate from request (modify API routes)
            return ConverterUtils.ConvertList<PageVisiteeBll, PageVisitee>(_historiqueAnalyticService.GetPagesVisiteesBll("", "").ToList());
        }
    }
}