using Historique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Historique.Controllers
{
    public class PageVisiteeController : ApiController
    {
        // GET api/pagevisitee
        /// <summary>
        /// Retourne toutes les pages visitées
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PageVisitee> Get()
        {
            return null;
        }

    }
}
