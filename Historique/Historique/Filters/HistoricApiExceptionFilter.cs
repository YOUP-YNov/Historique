using System;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http.Filters;
using Historique.Exceptions;
using Logger;

namespace Historique.Filters
{
    public class HistoricApiExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly string LOGGER_URL = WebConfigurationManager.AppSettings["api_logger_url"];
        private static readonly string APP_NAME = WebConfigurationManager.AppSettings["app_name"];

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var historicApiError = GetHistoricApiError(actionExecutedContext);

            GetErreur(actionExecutedContext).Save(LOGGER_URL);

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse<HistoricApiError>(historicApiError.StatusCode, historicApiError);
        }

        private HistoricApiError GetHistoricApiError(HttpActionExecutedContext actionExecutedContext)
        {
            HistoricApiError historicApiError = null;

            historicApiError = new HistoricApiError(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message);
            
            if (actionExecutedContext.Exception is HistoricEntityNotFoundException)
            {
                var exception = (HistoricEntityNotFoundException) actionExecutedContext.Exception;
                string message = String.Format("Entity {0} with criteria {1} = {2} not found",
                    exception.EntityName, exception.SearchCriteria, exception.SearchCriteriaValue);

                historicApiError = new HistoricApiError(HttpStatusCode.NotFound, message);
            }

            return historicApiError;
        }

        private LErreur GetErreur(HttpActionExecutedContext actionExecutedContext)
        {
            var erreur = new LErreur(actionExecutedContext.Exception, APP_NAME, "", 0);
            var foundException = actionExecutedContext.Exception as HistoricEntityNotFoundException;

            if (foundException != null)
            {
                var exception = foundException;
                erreur.Commentaire = String.Format("Entity '{0}' with criteria '{1}' = {2} not found.",
                    exception.EntityName, exception.SearchCriteria, exception.SearchCriteriaValue);
            }
            else
            {
                erreur.Commentaire = actionExecutedContext.Exception.Message;
            }

            return erreur;
        }
    }
}