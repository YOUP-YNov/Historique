using System.Web.Http;
using Historique.Exceptions;
using Historique.Filters;

namespace Historique.Controllers
{
    [HistoricApiExceptionFilter]
    public abstract class AbstractApiController<TEntity> : ApiController
    {
        protected void HandleEntityNotFound(string searchCriteria, string value)
        {
            throw new HistoricEntityNotFoundException(typeof(TEntity).Name, searchCriteria, value);
        }
    }
}