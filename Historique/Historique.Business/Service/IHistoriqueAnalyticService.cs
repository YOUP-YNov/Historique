using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Historique.Business.Models;

namespace Historique.Business.Mapper
{
    public interface IHistoriqueAnalyticService
    {
        IEnumerable<PageVisiteeBll> GetPagesVisiteesBll(string startDate, string endDate);

        // TODO Stats ...
    }
}
