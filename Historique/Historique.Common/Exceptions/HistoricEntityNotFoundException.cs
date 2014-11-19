using System;

namespace Historique.Exceptions
{
    public class HistoricEntityNotFoundException : Exception
    {
        public HistoricEntityNotFoundException(string entityName, string searchCriteria, string searchCriteriaValue)
        {
            this.EntityName = entityName;
            this.SearchCriteria = searchCriteria;
            this.SearchCriteriaValue = searchCriteriaValue;
        }

        public string EntityName { get; private set; }

        public string SearchCriteria { get; private set; }

        public string SearchCriteriaValue { get; private set; }
    }
}