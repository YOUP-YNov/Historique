using Historique.Mapper;
using Historique.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace Historique.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/evenement")]
    public class EvenementController : AbstractApiController<Evenement>
    {
        private IHistoriqueApiService _historiqueApiServiceService;

        public EvenementController(IHistoriqueApiService historiqueApiServiceService)
        {
            _historiqueApiServiceService = historiqueApiServiceService;
        }

        // GET api/evenement
        /// <summary>
        /// Retourne tous les évènements disponibles
        /// </summary>
        /// <returns></returns>

        [Route("")]
        public IEnumerable<Evenement> Get()
        {
            var evenements = _historiqueApiServiceService.GetAllEvenement() ?? new List<Evenement>();

            return evenements;
        }


        /// <summary>
        /// Retourne les évènements qui se déroulent durant une saisonalité donnée Format date yyyy-mm-dd
        /// </summary>
        /// <param name="dateDebut">date debut. Format YYYY-MM-dd</param>
        /// <param name="dateFin">date fin. Format YYYY-MM-dd</param>
        /// <returns></returns> 
        [HttpGet]
        [Route("EvenementParSaisonalite/{dateDebut}/{dateFin}")] //Etat =good
        public IEnumerable<Evenement> GetEvenementParSaisonalité(string dateDebut, string dateFin)
        {
            //TODO : Vérifier si les dates saisies sont correctes
            var evenements = new List<Evenement>();
            var tabDateDebut = dateDebut.Split('-');
            var tabDateFin = dateFin.Split('-');

            if(tabDateFin.Length==3&& tabDateDebut.Length==3)
            {
                var dateTimeDebut = new DateTime(Convert.ToInt32(tabDateDebut[0]),Convert.ToInt32(tabDateDebut[1]),Convert.ToInt32(tabDateDebut[2]));
                var dateTimeFin =new DateTime(Convert.ToInt32(tabDateFin[0]),Convert.ToInt32(tabDateFin[1]),Convert.ToInt32(tabDateFin[2]));

                var evenementsAll = _historiqueApiServiceService.GetAllEvenement();
                if (evenementsAll != null)
                    evenements = evenementsAll.Where(x => x.DateEvenement >= dateTimeDebut && x.DateEvenement <= dateTimeFin).ToList();
            }
            return evenements;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un code postale et d'une catégorie donnés
        /// </summary>
        /// <param name="codePostale">code postale.</param>
        /// <param name="categorie">categorie.</param>
        /// <returns></returns>
        [Route("EvenementByCateByCp/{codePostale}/{categorie}")]
        public IEnumerable<Evenement> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenementsAll = _historiqueApiServiceService.GetEvenementByCateByCp(codePostale, categorie);

            if (evenementsAll == null)
                evenementsAll = new List<Evenement>();
            //if (evenementsAll != null)
            //   evenements = evenementsAll.Where(x = x.CodePostale = codePostale && x.c


            return evenementsAll;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un code postale donné
        /// </summary>
        /// <param name="codePostale">code postale.</param>
        /// <returns></returns>
        [Route("EvenementByCp/{codePostale}")]
        public IEnumerable<Evenement> GetEvenementByCp(int codePostale)
        {
            var evenements = new List<Evenement>();
            var evenementsAll = _historiqueApiServiceService.GetEvenementByCp(codePostale);
            if (evenementsAll != null)
                evenements = evenementsAll.ToList();

            return evenements;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'une catégorie donnée
        /// </summary>
        /// <param name="categorie">categorie.</param>
        /// <returns></returns>
        [Route("EvenementByCategorie/{categorie}")]
        public IEnumerable<Evenement> GetEvenementByCategorie(string categorie)
        {
            var evenements = new List<Evenement>();
            var evenementsAll = _historiqueApiServiceService.GetAllEvenement();
            if (evenementsAll != null)
                evenements = evenementsAll.Where(x => x.Categorie.Libelle.Equals(categorie, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return evenements;
        }

        /// <summary>
        /// Retourne les évènements en fonction d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        /// <returns></returns>
        [Route("EvenementByUser/{userId}")]
        public IEnumerable<Evenement> GetEvenementByUtilisateurId(int userId)
        {
            var evenements = new List<Evenement>();
            var evenementsAll = _historiqueApiServiceService.GetEvenementParticipeByUserId(userId);
            if (evenementsAll != null)
                evenements = evenementsAll.ToList();

            return evenements;
        }


        [Route("{eventId}/Participants")]
        public IEnumerable<Utilisateur> GetParticipantsByEvenement(int eventId)
        {
            var participants = _historiqueApiServiceService.GetUtilisateurParticipeByEvenementId(eventId);
           
            return participants;
        }

        [Route("{eventId}/Createur")]
        public Utilisateur GetCreateurByEvenement(int eventId)
        {
            var participant = _historiqueApiServiceService.GetUtilisateurProposeByEvenementId(eventId);

            return participant;
        }

    }
}
