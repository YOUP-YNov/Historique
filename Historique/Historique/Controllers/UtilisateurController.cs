using Historique.Mapper;
using Historique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web;

namespace Historique.Controllers
{
    public class UtilisateurController : ApiController
    {
        // GET api/utilisateur
        /// <summary>
        /// Retourne tous les Utilisateurs
        /// </summary>
        /// <returns></returns>
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
        public IEnumerable<Utilisateur> GetTopAmis(int top)
        {
            var utilisateurs = new List<Utilisateur>();
            var utilisateursAll = Get();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbAmis).ToList();

            utilisateurs= utilisateurs.Take(top).ToList();

            return utilisateurs;
        }


        /// <summary>
        /// Retourne les utilisateurs ayants créé le plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetTopEvenementCree(int top)
        {
            var utilisateurs = new List<Utilisateur>();
            var utilisateursAll = Get();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbEvenmentPropose).ToList();

            utilisateurs = utilisateurs.Take(top).ToList();

            return utilisateurs;
        }

        /// <summary>
        /// Retourne les utilisateurs ayants participé au plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetToEvenementParticipe(int top)
        {
            var utilisateurs = new List<Utilisateur>();
            var utilisateursAll = Get();
            if (utilisateursAll != null)
                utilisateurs = utilisateursAll.OrderByDescending(x => x.NbEvenementParticipe).ToList();

            utilisateurs = utilisateurs.Take(top).ToList();

            return utilisateurs;
        }

        /// <summary>
        /// Retourne les utilisateurs dans une tranche d'age donnée
        /// </summary>
        /// <param name="ageDebut">age debut.</param>
        /// <param name="ageFin">age fin.</param>
        /// <returns></returns>
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
        public IEnumerable<Utilisateur> GetBySexe(bool homme)
        {
            var utilisateurs = new List<Utilisateur>();
            var utilisateursAll = Get();
            if(utilisateursAll !=null)
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
        public Utilisateur Get(int id)
        {
            var utilisateur = new Utilisateur();
            var utilisateursAll = Get();
            if(utilisateursAll !=null)
                utilisateur = utilisateursAll.SingleOrDefault(x => x.Id.Equals(id));

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
        public Utilisateur Get(string pseudo)
        {
            var utilisateurs = Get();
            var utilisateur = utilisateurs.SingleOrDefault(x => x.Pseudo.Equals(pseudo));
            if (utilisateur == null)
                utilisateur = new Utilisateur();
            return utilisateur;
        }


        // POST api/utilisateur
        public void Post([FromBody]string value)
        {
        }

        
    }
}
