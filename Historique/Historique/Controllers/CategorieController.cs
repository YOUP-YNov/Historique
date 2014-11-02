using Historique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Historique.Controllers
{
    public class CategorieController : ApiController
    {
        // GET api/categorie
        /// <summary>
        /// Retourne toutes les catégories d'évènement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categorie> Get()
        {
            return null;
        }

    }
}
