using System.Collections.Generic;
using Historique.Business.Models;

namespace Historique.Business.Mapper
{
    public interface IHistoriqueAnalyticService
    {
        IEnumerable<PageVisiteeBll> GetPagesVisiteesBll(string startDate, string endDate);
    }
}
