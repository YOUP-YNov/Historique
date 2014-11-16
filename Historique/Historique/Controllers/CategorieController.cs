using Historique.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Historique.Controllers
{
    public class CategorieController : AbstractApiController<Categorie>
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
