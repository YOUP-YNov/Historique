using System;
using System.Collections.Generic;
using System.Linq;
using Historique.DAL.DAL;
using Historique.Business.Models;
using Historique.Exceptions;
using Logger;

namespace Historique.Business.Mapper
{
    public class HistoriqueBll : IHistoriqueBll
    {
        private IHistorique _HistoriqueDAL;
        private string urlLogger="http://loggerasp.azurewebsites.net/";

        public HistoriqueBll(IHistorique historique)
        {
            _HistoriqueDAL = historique; 
        }

        public IEnumerable<CategorieBll> GetAllCategorieBll()
        {
            var allcatBll = new List<CategorieBll>();
            try
            {
                var allcat = _HistoriqueDAL.GetAllCategorie().ToList();
                allcatBll = Mapper.ToCategoriesSBll(allcat);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetAllCategorieBll").Save(urlLogger);
            }
            return allcatBll;
        }

        public IEnumerable<UtilisateurBll> GetAllUser()
        {
            var allusersBll = new List<UtilisateurBll>();
            try
            {
                var allusers = _HistoriqueDAL.GetAllUser().ToList();
                allusersBll = Mapper.ToUtilisateursBll(allusers);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetAllUser").Save(urlLogger);
            }
            return allusersBll;
        }

        public UtilisateurBll GetUserById(int id)
        {
            var userIDBll = new UtilisateurBll();
            try
            {
                var userID = _HistoriqueDAL.GetUserById(id);
                userIDBll = Mapper.ToUtilisateurBll(userID);
            }
            catch (Exception ex)
            {
                throw new HistoricEntityNotFoundException("Utilisateur", "id", id.ToString());
            }
            return userIDBll;
        }

        public UtilisateurBll GetUserByPseudo(string pseudo)
        {
            var userPseudoBll = new UtilisateurBll();
            try
            {
                var userPseudo = _HistoriqueDAL.GetUserByPseudo(pseudo);
                userPseudoBll = Mapper.ToUtilisateurBll(userPseudo);
            }
            catch (Exception ex) 
            {
                throw new HistoricEntityNotFoundException("Utilisateur", "pseudo", pseudo.ToString());
            }
            return userPseudoBll;
        }

        public IEnumerable<EvenementBll> GetAllEvenement()
        {
            var evenAllBll = new List<EvenementBll>();
            try
            {
                var evenAll = _HistoriqueDAL.GetAllEvenement().ToList();
                evenAllBll = Mapper.ToEvenementsBll(evenAll);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetAllEvenement").Save(urlLogger);
            }
            return evenAllBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenCatCpBll = new List<EvenementBll>();
            try
            {
                var evenCatCp = _HistoriqueDAL.GetEvenementByCateByCp(codePostale, categorie).ToList();
                evenCatCpBll = Mapper.ToEvenementsBll(evenCatCp);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementByCateByCp").Save(urlLogger);
            }
            return evenCatCpBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCp(int codePostale)
        {
            var evenCpBll = new List<EvenementBll>();
            try
            {
                var evenCp = _HistoriqueDAL.GetEvenementByCp(codePostale).ToList();
                evenCpBll = Mapper.ToEvenementsBll(evenCp);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementByCp").Save(urlLogger);
            }
            return evenCpBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenCatBll = new List<EvenementBll>();
            try
            {
                var evenCat = _HistoriqueDAL.GetEvenementByCat(categorie, dateDebut, dateFin).ToList();
                evenCatBll = Mapper.ToEvenementsBll(evenCat);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementByCat").Save(urlLogger);
            }
            return evenCatBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByDates(DateTime dateDebut, DateTime dateFin)
        {
            var evenDateBll = new List<EvenementBll>();
            try
            {
                var evenDate = _HistoriqueDAL.GetEvenementByDates(dateDebut, dateFin).ToList();
                evenDateBll = Mapper.ToEvenementsBll(evenDate);
            }
            catch (Exception ex) 
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementByDates").Save(urlLogger);
            }
            return evenDateBll;
        }

        public IEnumerable<EvenementBll> GetEvenementParticipeByUserId(int userId)
        {
            var evenParticipeUserBll = new List<EvenementBll>();
            try
            {
                var evenParticipeUser = _HistoriqueDAL.GetEvenementParticipeByUserId(userId).ToList();
                evenParticipeUserBll = Mapper.ToEvenementsBll(evenParticipeUser);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementParticipeByUserId").Save(urlLogger);
            }
            return evenParticipeUserBll;
        }

        public IEnumerable<UtilisateurBll> GetUtilisateurParticipeByEvenementId(int eventId)
        {
            var userParticipeEvenBll = new List<UtilisateurBll>();
            try
            {
                var userParticipeEven = _HistoriqueDAL.GetUtilisateurParticipeByEvenementId(eventId).ToList();
                userParticipeEvenBll = Mapper.ToUtilisateursBll(userParticipeEven);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetUtilisateurParticipeByEvenementId").Save(urlLogger);

            }
            return userParticipeEvenBll;
        }

        public IEnumerable<EvenementBll> GetEvenementProposeByUserId(int userId)
        {
            var evenProposeUserBll = new List<EvenementBll>();
            try
            {
                var evenProposeUser = _HistoriqueDAL.GetEvenementProposeByUserId(userId).ToList();
                evenProposeUserBll = Mapper.ToEvenementsBll(evenProposeUser);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetEvenementProposeByUserId").Save(urlLogger);
            }
            return evenProposeUserBll;
        }
    
        public UtilisateurBll GetUtilisateurProposeByEvenementId(int eventId)
        {
            var userProposeEvenBll = new UtilisateurBll();
            try
            {
                var userProposeEven = _HistoriqueDAL.GetUtilisateurProposeByEvenementId(eventId);
                userProposeEvenBll = Mapper.ToUtilisateurBll(userProposeEven);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique.Business", "Mapper.HistoriqueBll.GetUtilisateurProposeByEvenementId").Save(urlLogger);
            }
            return userProposeEvenBll;
        }
    }
}
