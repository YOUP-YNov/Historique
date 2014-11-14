using Historique.Mapper;
using Historique.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Historique.Controllers
{
    [RoutePrefix("api/utilisateur")]
    public class UtilisateurController : ApiController
    {
        // GET api/utilisateur
        /// <summary>D:\WORK\git\VS-GIT\Historique\Historique\Controllers\UtilisateurController.cs
        /// Retourne tous les Utilisateurs
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<Utilisateur> Get()
        {
            var utilisateurs = HistoriqueAPI.GetAllUser();
            if (utilisateurs == null)
                utilisateurs = new List<Utilisateur>();
            
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
            var utilisateursAll = Get();
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
            var utilisateursAll = Get();
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
            var utilisateursAll = Get();
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
            var utilisateursAll = Get();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.Where(x => x.Age >= ageDebut && x.Age <= ageFin).ToList();

            if (utilisateurs == null)
                utilisateurs = new List<Utilisateur>();

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
            var utilisateursAll = Get();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.Where(x => x.IsHomme == homme).ToList();

            if (utilisateurs == null)
                utilisateurs = new List<Utilisateur>();

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
            var utilisateur = HistoriqueAPI.GetUserById(id);
           
            //if (utilisateur == null)
            //    utilisateur = new Utilisateur();

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

            var utilisateur = HistoriqueAPI.GetUserByPseudo(pseudo);

            return utilisateur;
        }


        // POST api/utilisateur
        public void Post([FromBody]string value)
        {
        }

        
    }
}
