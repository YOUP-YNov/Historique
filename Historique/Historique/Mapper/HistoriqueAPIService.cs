using System;
using System.Collections.Generic;
using System.Linq;
using Historique.Business.Mapper;
using Historique.Models;
using Logger;

namespace Historique.Mapper
{
    public class HistoriqueApiService : IHistoriqueApiService
    {
        private IHistoriqueBll _historiqueBll;
        private static string urlLogger = "http://loggerasp.azurewebsites.net/";

        public HistoriqueApiService(IHistoriqueBll historiqueBll)
        {
            _historiqueBll = historiqueBll;
        }

        public IEnumerable<Categorie> GetAllCategorieBll()
        {
            var allcatBll = new List<Categorie>();
            try
            {
                var allcat = _historiqueBll.GetAllCategorieBll().ToList();
                allcatBll = MapperExpoAPI.ToCategories(allcat);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetAllcategorieBLL").Save(urlLogger);

            }
            return allcatBll;
        }

        public IEnumerable<Utilisateur> GetAllUser()
        {
            var allusersBll = new List<Utilisateur>();
            try
            {
                var allusers = _historiqueBll.GetAllUser().ToList();
                allusersBll = MapperExpoAPI.ToUtilisateurs(allusers);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetAllUser").Save(urlLogger);
            }
            return allusersBll;
        }

        public Utilisateur GetUserById(int id)
        {
            var userIDBll = new Utilisateur();
            try
            {
                var userID = _historiqueBll.GetUserById(id);
                userIDBll = MapperExpoAPI.ToUtilisateur(userID);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetUserById").Save(urlLogger);
            }
            return userIDBll;
        }

        public Utilisateur GetUserByPseudo(string pseudo)
        {
            var userPseudoBll = new Utilisateur();
            try
            {
                var userPseudo = _historiqueBll.GetUserByPseudo(pseudo);
                userPseudoBll = MapperExpoAPI.ToUtilisateur(userPseudo);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetUserByPseudo").Save(urlLogger);
            }
            return userPseudoBll;
        }

        public IEnumerable<Evenement> GetAllEvenement()
        {
            var evenAllBll = new List<Evenement>();
            try
            {
                var evenAll = _historiqueBll.GetAllEvenement().ToList();
                evenAllBll = MapperExpoAPI.ToEvenements(evenAll);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetAllEvenement").Save(urlLogger);
            }
            return evenAllBll;
        }

        public IEnumerable<Evenement> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenCatCpBll = new List<Evenement>();
            try
            {
                var evenCatCp = _historiqueBll.GetEvenementByCateByCp(codePostale, categorie).ToList();
                evenCatCpBll = MapperExpoAPI.ToEvenements(evenCatCp);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementByCateByCp").Save(urlLogger);
            }
            return evenCatCpBll;
        }

        public IEnumerable<Evenement> GetEvenementByCp(int codePostale)
        {
            var evenCpBll = new List<Evenement>();
            try
            {
                var evenCp = _historiqueBll.GetEvenementByCp(codePostale).ToList();
                evenCpBll = MapperExpoAPI.ToEvenements(evenCp);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementByCp").Save(urlLogger);
            }
            return evenCpBll;
        }

        public IEnumerable<Evenement> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenCatBll = new List<Evenement>();
            try
            {
                var evenCat = _historiqueBll.GetEvenementByCat(categorie, dateDebut, dateFin).ToList();
                evenCatBll = MapperExpoAPI.ToEvenements(evenCat);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementByCat").Save(urlLogger);
            }
            return evenCatBll;
        }

        public IEnumerable<Evenement> GetEvenementByDates(DateTime dateDebut, DateTime dateFin)
        {
            var evenDateBll = new List<Evenement>();
            try
            {
                var evenDate = _historiqueBll.GetEvenementByDates(dateDebut, dateFin).ToList();
                evenDateBll = MapperExpoAPI.ToEvenements(evenDate);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementByDates").Save(urlLogger);
            }
            return evenDateBll;
        }

        public IEnumerable<Evenement> GetEvenementParticipeByUserId(int userId)
        {
            var evenParticipeUserBll = new List<Evenement>();
            try
            {
                var evenParticipeUser = _historiqueBll.GetEvenementParticipeByUserId(userId).ToList();
                evenParticipeUserBll = MapperExpoAPI.ToEvenements(evenParticipeUser);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementParticipeByUserId").Save(urlLogger);
            }
            return evenParticipeUserBll;
        }

        public IEnumerable<Utilisateur> GetUtilisateurParticipeByEvenementId(int eventId)
        {
            var userParticipeEvenBll = new List<Utilisateur>();
            try
            {
                var userParticipeEvent = _historiqueBll.GetUtilisateurParticipeByEvenementId(eventId).ToList();
                userParticipeEvenBll = MapperExpoAPI.ToUtilisateurs(userParticipeEvent);
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
                var evenProposeUser = _historiqueBll.GetEvenementProposeByUserId(userId).ToList();
                evenProposeUserBll = MapperExpoAPI.ToEvenements(evenProposeUser);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetEvenementProposeByUserId").Save(urlLogger);
            }
            return evenProposeUserBll;
        }

        public Utilisateur GetUtilisateurProposeByEvenementId(int eventId)
        {
            var userProposeEvenBll = new Utilisateur();
            try
            {
                var userProposeEven = _historiqueBll.GetUtilisateurProposeByEvenementId(eventId);
                userProposeEvenBll = MapperExpoAPI.ToUtilisateur(userProposeEven);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.HistoriqueApiService.GetUtilisateurProposeByEvenementId").Save(urlLogger);
            }
            return userProposeEvenBll;
        }
    }
}