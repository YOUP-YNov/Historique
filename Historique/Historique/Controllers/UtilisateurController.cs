using AutoMapper.Internal;
using Historique.Mapper;
using Historique.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Historique.Controllers
{
    [RoutePrefix("api/utilisateur")]
    public class UtilisateurController : AbstractApiController<Utilisateur>
    {
        private IHistoriqueApiService _historiqueApiServiceService;

        public UtilisateurController(IHistoriqueApiService historiqueApiServiceService)
        {
            _historiqueApiServiceService = historiqueApiServiceService;
        }

        // GET api/utilisateur
        //D:\WORK\git\VS-GIT\Historique\Historique\Controllers\UtilisateurController.cs
        /// <summary>
        /// Retourne tous les Utilisateurs
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Utilisateur> Get()
        {
            var utilisateurs = _historiqueApiServiceService.GetAllUser() ?? new List<Utilisateur>();

            return utilisateurs;
        }


        /// <summary>
        /// Retourne les utilisateurs ayants le plus d'amis
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("TopAmis/{top}")]
        public IEnumerable<Utilisateur> GetTopAmis(int top)
        {
            IEnumerable<Utilisateur> utilisateurs = null;
            var utilisateursAll = _historiqueApiServiceService.GetAllUser();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbAmis);

            utilisateurs= utilisateurs.Take(top).ToList();

            return utilisateurs;
        }


        /// <summary>
        /// Retourne les utilisateurs ayants créé le plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("TopEventCree/{top}")]
        public IEnumerable<Utilisateur> GetTopEvenementCree(int top)
        {
            IEnumerable<Utilisateur> utilisateurs = null;
            var utilisateursAll = _historiqueApiServiceService.GetAllUser();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbEvenmentPropose);

            utilisateurs = utilisateurs.Take(top).ToList();

            return utilisateurs;
        }

        /// <summary>
        /// Retourne les utilisateurs ayants participé au plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("TopEventParticipe/{top}")]
        public IEnumerable<Utilisateur> GetToEvenementParticipe(int top)
        {
            IEnumerable<Utilisateur> utilisateurs = null;
            var utilisateursAll = _historiqueApiServiceService.GetAllUser();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbEvenementParticipe);

            utilisateurs = utilisateurs.Take(top).ToList();

            return utilisateurs;
        }

        /// <summary>
        /// Retourne les utilisateurs dans une tranche d'age donnée
        /// </summary>
        /// <param name="ageDebut">age debut.</param>
        /// <param name="ageFin">age fin.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByTrancheAge/{ageDebut}/{ageFin}")]
        public IEnumerable<Utilisateur> GetByTrancheAge(int ageDebut, int ageFin)
        {
            var utilisateurs = new List<Utilisateur>();

            var utilisateursAll = _historiqueApiServiceService.GetAllUser();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.Where(x => x.Age >= ageDebut && x.Age <= ageFin).ToList();

            return utilisateurs;
        }

        /// <summary>
        /// Retourne les utilisateurs d'un même sexe
        /// </summary>
        /// <param name="homme">if set to <c>true</c> [homme].</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBySexe/{homme}")]
        public IEnumerable<Utilisateur> GetBySexe(bool homme)
        {
            var utilisateurs = new List<Utilisateur>();
            var utilisateursAll = _historiqueApiServiceService.GetAllUser();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.Where(x => x.IsHomme == homme).ToList();

            return utilisateurs;
        }

        ///// <summary>
        ///// Retourne les utilisateurs participants d'un évènement
        ///// </summary>
        ///// <param name="evenement_Id">l'identifiant de l'évènement.</param>
        ///// <returns></returns>
        //public IEnumerable<Utilisateur> GetParticipants(int evenement_Id)
        //{
        //    var utilisateursAll = Get();
        //    var utilisateurs = utilisateursAll.SingleOrDefault(x => x.Id.Equals(id));
        //    if (utilisateurs == null)
        //        utilisateurs = new List<Utilisateur>();
        //    return utilisateurs;
        //}


        // GET api/utilisateur/5
        /// <summary>
        /// Retourne l'utilisateur correspondant à l'indentifiant
        /// </summary>
        /// <param name="id">Indentifiant</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public Utilisateur Get(int id)
        {
            var utilisateur = _historiqueApiServiceService.GetUserById(id);
           
            /** TODO throw HistoricEntityNotFoundException in case of entity not found for all controllers + extend from AbstractApiController (catch Exception)
             *  TODO return null in mapper tiers
             */

            // user is never null (See HistoriqueAPIService.GetUserById(..);)
            if (utilisateur == null)
            {
                HandleEntityNotFound("id", id.ToNullSafeString());
            }

            return utilisateur;
        }

        // GET api/utilisateur/pseudo1
        /// <summary>
        /// Retourne l'utilisateur correspondant au pseudo
        /// </summary>
        /// <param name="pseudo">le pseudo.</param>
        /// <returns></returns>
        [Route("{pseudo}")]
        public Utilisateur Get(string pseudo)
        {
            var utilisateur = _historiqueApiServiceService.GetUserByPseudo(pseudo);

            return utilisateur;
        }


        /// <summary>
        /// Retourne les évènements créés par l'utilisateur
        /// </summary>
        /// <param name="userId">identifiant.</param>
        /// <returns></returns>
        [Route("{userId}/EvenementsCrees")]
        public IEnumerable<Evenement> GetEvenementsCrees(int userId)
        {
            var evenements = _historiqueApiServiceService.GetEvenementProposeByUserId(userId);

            return evenements;
        }

        /// <summary>
        /// Retourne les évènements où l'utilisateur à participés
        /// </summary>
        /// <param name="userId">identifiant.</param>
        /// <returns></returns>
        [Route("{userId}/EvenementsParticipes")]
        public IEnumerable<Evenement> GetEvenementsParticipes(int userId)
        {
            var evenements = _historiqueApiServiceService.GetEvenementParticipeByUserId(userId);

            return evenements;
        }
    }
}
