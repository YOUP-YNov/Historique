using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Historique.Business;
using Historique.Business.Mapper;
using Historique.Models;

namespace Historique.Mapper
{
    public class HistoriqueAPI
    {
        private HistoriqueBll _HistoriqueBll;

        public HistoriqueAPI()
        {
            _HistoriqueBll = new HistoriqueBll(); 
        }

        public IEnumerable<Categorie> GetAllCategorieBll()
        {
            var allcatBll = new List<Categorie>();
            try
            {
                var allcat = _HistoriqueBll.GetAllCategorieBll();
            }
            catch (Exception ex) { }
            return allcatBll;
        }

        public IEnumerable<Utilisateur> GetAllUser()
        {
            var allusersBll = new List<Utilisateur>();
            try
            {
                var allusers = _HistoriqueBll.GetAllUser();
            }
            catch (Exception ex) { }
            return allusersBll;
        }

        public Utilisateur GetUserById(int id)
        {
            var userIDBll = new Utilisateur();
            try
            {
                var userID = _HistoriqueBll.GetUserById(id);
            }
            catch (Exception ex) { }
            return userIDBll;
        }

        public Utilisateur GetUserByPseudo(string pseudo)
        {
            var userPseudoBll = new Utilisateur();
            try
            {
                var userPseudo = _HistoriqueBll.GetUserByPseudo(pseudo);
            }
            catch (Exception ex) { }
            return userPseudoBll;
        }

        public IEnumerable<Evenement> GetAllEvenement()
        {
            var evenAllBll = new List<Evenement>();
            try
            {
                var evenAll = _HistoriqueBll.GetAllEvenement();
            }
            catch (Exception ex) { }
            return evenAllBll;
        }

        public IEnumerable<Evenement> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenCatCpBll = new List<Evenement>();
            try
            {
                var evenCatCp = _HistoriqueBll.GetEvenementByCateByCp(codePostale, categorie);
            }
            catch (Exception ex) { }
            return evenCatCpBll;
        }

        public IEnumerable<Evenement> GetEvenementByCp(int codePostale)
        {
            var evenCpBll = new List<Evenement>();
            try
            {
                var evenCp = _HistoriqueBll.GetEvenementByCp(codePostale);
            }
            catch (Exception ex) { }
            return evenCpBll;
        }

        public IEnumerable<Evenement> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenCatBll = new List<Evenement>();
            try
            {
                var evenCat = _HistoriqueBll.GetEvenementByCat(categorie, dateDebut, dateFin);
            }
            catch (Exception ex) { }
            return evenCatBll;
        }

        public IEnumerable<Evenement> GetEvenementByDates(DateTime dateDebut, DateTime dateFin)
        {
            var evenDateBll = new List<Evenement>();
            try
            {
                var evenDate = _HistoriqueBll.GetEvenementByDates(dateDebut, dateFin);
            }
            catch (Exception ex) { }
            return evenDateBll;
        }

        public IEnumerable<Evenement> GetEvenementParticipeByUserId(int userId)
        {
            var evenParticipeUserBll = new List<Evenement>();
            try
            {
                var evenParticipeUser = _HistoriqueBll.GetEvenementParticipeByUserId(userId);
            }
            catch (Exception ex)
            {
            }
            return evenParticipeUserBll;
        }

        public IEnumerable<Utilisateur> GetUtilisateurParticipeByEvenementId(int eventId)
        {
            var userParticipeEvenBll = new List<Utilisateur>();
            try
            {
                var userParticipeEven = _HistoriqueBll.GetUtilisateurParticipeByEvenementId(eventId);
            }
            catch (Exception ex)
            {
            }
            return userParticipeEvenBll;
        }

        public IEnumerable<Evenement> GetEvenementProposeByUserId(int userId)
        {
            var evenProposeUserBll = new List<Evenement>();
            try
            {
                var evenProposeUser = _HistoriqueBll.GetEvenementProposeByUserId(userId);
            }
            catch (Exception ex)
            {
            }
            return evenProposeUserBll;
        }
    
        public Utilisateur GetUtilisateurProposeByEvenementId(int eventId)
        {
            var userProposeEvenBll = new Utilisateur();
            try
            {
                var userProposeEven = _HistoriqueBll.GetUtilisateurProposeByEvenementId(eventId);
            }
            catch (Exception ex)
            {
            }
            return userProposeEvenBll;
        }
    }
}