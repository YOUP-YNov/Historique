﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Historique.DAL.DAL;
using Historique.Business.Models;

namespace Historique.Business.Mapper
{
    public class HistoriqueBll
    {
        private DAL.DAL.Historique _HistoriqueDAL;

        public HistoriqueBll()
        {
            _HistoriqueDAL = new DAL.DAL.Historique(); 
        }

        public IEnumerable<CategorieBll> GetAllCategorieBll()
        {
            var allcatBll = new List<CategorieBll>();
            try
            {
                var allcat = _HistoriqueDAL.GetAllCategorie();
            }
            catch (Exception ex) { }
            return allcatBll;
        }

        public IEnumerable<UtilisateurBll> GetAllUser()
        {
            var allusersBll = new List<UtilisateurBll>();
            try
            {
                var allusers = _HistoriqueDAL.GetAllUser();
            }
            catch (Exception ex) { }
            return allusersBll;
        }

        public UtilisateurBll GetUserById(int id)
        {
            var userIDBll = new UtilisateurBll();
            try
            {
                var userID = _HistoriqueDAL.GetUserById(id);
            }
            catch (Exception ex) { }
            return userIDBll;
        }

        public UtilisateurBll GetUserByPseudo(string pseudo)
        {
            var userPseudoBll = new UtilisateurBll();
            try
            {
                var userPseudo = _HistoriqueDAL.GetUserByPseudo(pseudo);
            }
            catch (Exception ex) { }
            return userPseudoBll;
        }

        public IEnumerable<EvenementBll> GetAllEvenement()
        {
            var evenAllBll = new List<EvenementBll>();
            try
            {
                var evenAll = _HistoriqueDAL.GetAllEvenement();
            }
            catch (Exception ex) { }
            return evenAllBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenCatCpBll = new List<EvenementBll>();
            try
            {
                var evenCatCp = _HistoriqueDAL.GetEvenementByCateByCp(codePostale, categorie);
            }
            catch (Exception ex) { }
            return evenCatCpBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCp(int codePostale)
        {
            var evenCpBll = new List<EvenementBll>();
            try
            {
                var evenCp = _HistoriqueDAL.GetEvenementByCp(codePostale);
            }
            catch (Exception ex) { }
            return evenCpBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenCatBll = new List<EvenementBll>();
            try
            {
                var evenCat = _HistoriqueDAL.GetEvenementByCat(categorie, dateDebut, dateFin);
            }
            catch (Exception ex) { }
            return evenCatBll;
        }

        public IEnumerable<EvenementBll> GetEvenementByDates(DateTime dateDebut, DateTime dateFin)
        {
            var evenDateBll = new List<EvenementBll>();
            try
            {
                var evenDate = _HistoriqueDAL.GetEvenementByDates(dateDebut, dateFin);
            }
            catch (Exception ex) { }
            return evenDateBll;
        }

        public IEnumerable<EvenementBll> GetEvenementParticipeByUserId(int userId)
        {
            var evenParticipeUserBll = new List<EvenementBll>();
            try
            {
                var evenParticipeUser = _HistoriqueDAL.GetEvenementParticipeByUserId(userId);
            }
            catch (Exception ex)
            {
            }
            return evenParticipeUserBll;
        }

        public IEnumerable<UtilisateurBll> GetUtilisateurParticipeByEvenementId(int eventId)
        {
            var userParticipeEvenBll = new List<UtilisateurBll>();
            try
            {
                var userParticipeEven = _HistoriqueDAL.GetUtilisateurParticipeByEvenementId(eventId);
            }
            catch (Exception ex)
            {
            }
            return userParticipeEvenBll;
        }

        public IEnumerable<EvenementBll> GetEvenementProposeByUserId(int userId)
        {
            var evenProposeUserBll = new List<EvenementBll>();
            try
            {
                var evenProposeUser = _HistoriqueDAL.GetEvenementProposeByUserId(userId);
            }
            catch (Exception ex)
            {
            }
            return evenProposeUserBll;
        }
    
        public UtilisateurBll GetUtilisateurProposeByEvenementId(int eventId)
        {
            var userProposeEvenBll = new UtilisateurBll();
            try
            {
                var userProposeEven = _HistoriqueDAL.GetUtilisateurProposeByEvenementId(eventId);
            }
            catch (Exception ex)
            {
            }
            return userProposeEvenBll;
        }
    }
}
