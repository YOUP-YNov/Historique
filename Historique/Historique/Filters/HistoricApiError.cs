using System.Net;

namespace Historique.Filters
{
    public class HistoricApiError
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Description { get; set; }

        public HistoricApiError(HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }
    }
}