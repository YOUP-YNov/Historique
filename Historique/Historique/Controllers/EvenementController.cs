using Historique.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Historique.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EvenementController : AbstractApiController<Evenement>
    {

        // GET api/evenement
        /// <summary>
        /// Retourne tous les évènements disponibles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Evenement> Get()
        {
            return null;
        }

 
        /// <summary>
        /// Retourne les évènements qui se déroulent durant une saisonalité donnée
        /// </summary>
        /// <param name="dateDebut">date debut.</param>
        /// <param name="dateFin">date fin.</param>
        /// <returns></returns>
        public IEnumerable<Evenement> GetEvenementParSaisonalité(DateTime dateDebut, DateTime dateFin)
        {
            return null;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un code postale et d'une catégorie donnés
        /// </summary>
        /// <param name="codePostale">code postale.</param>
        /// <param name="categorie">categorie.</param>
        /// <returns></returns>
        public IEnumerable<Evenement> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            return null;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un code postale donné
        /// </summary>
        /// <param name="codePostale">code postale.</param>
        /// <returns></returns>
        public IEnumerable<Evenement> GetEvenementByCp(int codePostale)
        {
            return null;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'une catégorie donnée
        /// </summary>
        /// <param name="categorie">categorie.</param>
        /// <returns></returns>
        public IEnumerable<Evenement> GetEvenementByCategorie(string categorie)
        {
            return null;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        /// <returns></returns>
        public IEnumerable<Evenement> GetEvenementByUtilisateurId(int userId)
        {
            return null;
        }

    }
}
