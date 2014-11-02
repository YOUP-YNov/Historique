using Historique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            return null;
        }


        /// <summary>
        /// Retourne les utilisateurs ayants le plus d'amis
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetTopAmis(int top)
        {
            return null;
        }


        /// <summary>
        /// Retourne les utilisateurs ayants créé le plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetTopEvenementCree(int top)
        {
            return null;
        }

        /// <summary>
        /// Retourne les utilisateurs ayants participé au plus d'évènement
        /// </summary>
        /// <param name="top">le top désiré (ex : top 5, top 10...)</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetToEvenementParticipe(int top)
        {
            return null;
        }

        /// <summary>
        /// Retourne les utilisateurs dans une tranche d'age donnée
        /// </summary>
        /// <param name="ageDebut">age debut.</param>
        /// <param name="ageFin">age fin.</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetByTrancheAge(int ageDebut, int ageFin)
        {
            return null;
        }

        /// <summary>
        /// Retourne les utilisateurs d'un même sexe
        /// </summary>
        /// <param name="homme">if set to <c>true</c> [homme].</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetBySexe(bool homme)
        {
            return null;
        }

        /// <summary>
        /// Retourne les utilisateurs participants d'un évènement
        /// </summary>
        /// <param name="evenement_Id">l'identifiant de l'évènement.</param>
        /// <returns></returns>
        public IEnumerable<Utilisateur> GetParticipants(int evenement_Id)
        {
            return null;
        }


        // GET api/utilisateur/5
        /// <summary>
        /// Retourne l'utilisateur correspondant à l'indentifiant
        /// </summary>
        /// <param name="id">Indentifiant</param>
        /// <returns></returns>
        public Utilisateur Get(int id)
        {
            return null;
        }

        // GET api/utilisateur/pseudo1
        /// <summary>
        /// Retourne l'utilisateur correspondant au pseudo
        /// </summary>
        /// <param name="pseudo">le pseudo.</param>
        /// <returns></returns>
        public Utilisateur Get(string pseudo)
        {
            return null;
        }


        // POST api/utilisateur
        public void Post([FromBody]string value)
        {
        }

        
    }
}
