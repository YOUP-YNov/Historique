using Historique.Models;
using Historique.Mapper;
using System.Collections.Generic;
using System.Web.Http;

namespace Historique.Controllers
{
    [RoutePrefix("api/categorie")]
    public class CategorieController : AbstractApiController<Categorie>
    {
        private IHistoriqueApiService _historiqueApiServiceService;

        public CategorieController(IHistoriqueApiService historiqueApiServiceService)
        {
            _historiqueApiServiceService = historiqueApiServiceService;
        }

        // GET api/categorie
        /// <summary>
        /// Retourne toutes les catégories d'évènement
        /// </summary>
        /// <returns>Toutes les catégories</returns>
        [Route("")]
        public IEnumerable<Categorie> Get()
        {
            var categories = _historiqueApiServiceService.GetAllCategorieBll() ?? new List<Categorie>();

            return categories;
        }

    }
}
