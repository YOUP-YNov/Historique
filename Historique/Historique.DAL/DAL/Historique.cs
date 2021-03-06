﻿using System;
using System.Collections.Generic;
using System.Linq;
using Historique.DAL.DAO;
using Historique.Exceptions;

namespace Historique.DAL.DAL
{
    public partial class Historique : IHistorique
    {
        #region Properties
        private HistoriqueTableAdapters.UtilisateurEvenementParticipeTableAdapter _UtilisateurEvenementParticipeService;
        public HistoriqueTableAdapters.UtilisateurEvenementParticipeTableAdapter UtilisateurEvenementParticipeService
        {
            get
            {
                if (_UtilisateurEvenementParticipeService == null)
                    _UtilisateurEvenementParticipeService = new HistoriqueTableAdapters.UtilisateurEvenementParticipeTableAdapter();
                return _UtilisateurEvenementParticipeService;
            }
            set
            {
                _UtilisateurEvenementParticipeService = value;
            }
        }

        private HistoriqueTableAdapters.UtilisateurEvenementProposeTableAdapter _UtilisateurEvenementProposeService;
        public HistoriqueTableAdapters.UtilisateurEvenementProposeTableAdapter UtilisateurEvenementProposeService
        {
            get
            {
                if (_UtilisateurEvenementProposeService == null)
                    _UtilisateurEvenementProposeService = new HistoriqueTableAdapters.UtilisateurEvenementProposeTableAdapter();
                return _UtilisateurEvenementProposeService;
            }
            set
            {
                _UtilisateurEvenementProposeService = value;
            }
        }

        private HistoriqueTableAdapters.UT_UtilisateurTableAdapter _UserService;

        public HistoriqueTableAdapters.UT_UtilisateurTableAdapter UserService
        {
            get
            {
                if (_UserService == null)
                    _UserService = new HistoriqueTableAdapters.UT_UtilisateurTableAdapter();
                return _UserService;
            }
            set
            {
                _UserService = value;
            }
        }

        private HistoriqueTableAdapters.ps_GetAllEvenementTableAdapter _EvenementService;

        public HistoriqueTableAdapters.ps_GetAllEvenementTableAdapter EvenementService
        {
            get
            {
                if (_EvenementService == null)
                    _EvenementService = new HistoriqueTableAdapters.ps_GetAllEvenementTableAdapter();
                return _EvenementService;
            }
            set
            {
                _EvenementService = value;
            }
        }

        private HistoriqueTableAdapters.UT_CategorieTableAdapter _CategorieService;

        public HistoriqueTableAdapters.UT_CategorieTableAdapter CategorieService
        {
            get
            {
                if (_CategorieService == null)
                    _CategorieService = new HistoriqueTableAdapters.UT_CategorieTableAdapter();
                return _CategorieService;
            }
            set
            {
                _CategorieService = value;
            }
        }

        private HistoriqueTableAdapters.EVE_EvenementTableAdapter _EveCat;
        public HistoriqueTableAdapters.EVE_EvenementTableAdapter EveCat
        {
            get
            {
                if (_EveCat == null)
                    _EveCat = new HistoriqueTableAdapters.EVE_EvenementTableAdapter();
                return _EveCat;
            }
            set
            {
                _EveCat = value;
            }
        }

        #endregion Properties

        #region Methods

        public IEnumerable<CategorieDao> GetAllCategorie()
        {
            var cat = CategorieService.GetData();
            List<CategorieDao> catDaoList = (List<CategorieDao>)cat.ToDaoCategories();
            return catDaoList;
        }

        public IEnumerable<UtilisateurDao> GetAllUser()
        {
            var users = UserService.GetData();
            List<UtilisateurDao> userDaoList = (List<UtilisateurDao>)users.ToDaoUtilisateurs();

            foreach (var user in userDaoList)
            {
                var nbAmis = UserService.NbAmisByPseudo(user.Pseudo);
                var nbEventPropose = UserService.NbEvenementProposeByPseudo(user.Pseudo);
                var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(user.Pseudo);
                user.NbAmis = nbAmis.Value;
                user.NbEvenementParticipe = nbEventParticipe.Value;
                user.NbEvenmentPropose = nbEventPropose.Value;
            }
            return userDaoList;
        }

        public UtilisateurDao GetUserById(int id)
        {
            var nbAmis = UserService.NbAmis(id);
            var nbEventPropose = Convert.ToInt32(UserService.NbEvenementPropose(id));
            var nbEventParticipe = Convert.ToInt32(UserService.NbEvenementParticipe(id));

            var result = UserService.GetDataById(id);

            List<UtilisateurDao> userDaoList = (List<UtilisateurDao>)result.ToDaoUtilisateurs();
            var userDao = userDaoList.First();

            if (userDao == null)
            {
                throw new HistoricEntityNotFoundException("Utilisateur", "id", id.ToString());
            }

            userDao.NbAmis = nbAmis.Value;
            userDao.NbEvenementParticipe = nbEventParticipe;
            userDao.NbEvenmentPropose = nbEventPropose;
            return userDao;
        }

        public UtilisateurDao GetUserByPseudo(string pseudo)
        {
            var nbAmis = UserService.NbAmisByPseudo(pseudo);
            var nbEventPropose = UserService.NbEvenementProposeByPseudo(pseudo);
            var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(pseudo);

            var result = UserService.GetDataByPseudo(pseudo);
            List<UtilisateurDao> userDaoList = (List<UtilisateurDao>)result.ToDaoUtilisateurs();
            var userDao = userDaoList.First();

            if (userDao == null)
            {
                throw new HistoricEntityNotFoundException("Utilisateur", "pseudo", pseudo.ToString());
            }

            userDao.NbAmis = nbAmis.Value;
            userDao.NbEvenementParticipe = nbEventParticipe.Value;
            userDao.NbEvenmentPropose = nbEventPropose.Value;
            return userDao;
        }

        public IEnumerable<EvenementDao> GetAllEvenement()
        {
            var constraints =ps_GetAllEvenement.Constraints;
            var evenement = EvenementService.GetData();
            List<EvenementDao> eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var evenement = EvenementService.GetDataByCateByCp(codePostale, categorie);
            List<EvenementDao> eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByCp(int codePostale)
        {
            var evenement = EvenementService.GetDataByCp(codePostale);
            List<EvenementDao> eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenement = EveCat.GetDataByCat(categorie, dateDebut, dateFin);
            List<EvenementDao> eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByDates(DateTime dateDebut, DateTime dateFin)
        {
            var evenement = EveCat.GetDataByEvenDates(dateDebut, dateFin);
            List<EvenementDao> eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementParticipeByUserId(int userId)
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                if (UtilisateurEvenementParticipeService != null)
                {
                    var evenement = UtilisateurEvenementParticipeService.GetEvenementParticipeByUserId(userId);
                    eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
                    foreach (var eventDao in eventDaoList)
                    {
                        eventDao.Participants = GetUtilisateurParticipeByEvenementId(eventDao.Id);
                        eventDao.Createur = GetUtilisateurProposeByEvenementId(eventDao.Id);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return eventDaoList;
        }
        public IEnumerable<UtilisateurDao> GetUtilisateurParticipeByEvenementId(int eventId)
        {
            var userDaoList = new List<UtilisateurDao>();
            try
            {
                if (UtilisateurEvenementParticipeService != null)
                {
                    var user = UtilisateurEvenementParticipeService.GetUtilisateurByEvenementId(eventId);
                    userDaoList = (List<UtilisateurDao>)user.ToDaoUtilisateurs();
                    foreach (var userDao in userDaoList)
                    {
                        if (!string.IsNullOrEmpty(userDao.Pseudo))
                        {
                            var nbAmis = UserService.NbAmisByPseudo(userDao.Pseudo);
                            var nbEventPropose = UserService.NbEvenementProposeByPseudo(userDao.Pseudo);
                            var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(userDao.Pseudo);
                            userDao.NbAmis = nbAmis.Value;
                            userDao.NbEvenementParticipe = nbEventParticipe.Value;
                            userDao.NbEvenmentPropose = nbEventPropose.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return userDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementProposeByUserId(int userId)
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                if (UtilisateurEvenementParticipeService != null)
                {
                    var evenement = UtilisateurEvenementProposeService.GetEvenementProposeByUserId(userId);
                    eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
                    foreach (var eventDao in eventDaoList)
                    {
                        eventDao.Participants = GetUtilisateurParticipeByEvenementId(eventDao.Id);
                        eventDao.Createur = GetUtilisateurProposeByEvenementId(eventDao.Id);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return eventDaoList;
        }
        public UtilisateurDao GetUtilisateurProposeByEvenementId(int eventId)
        {
            var userDao = new UtilisateurDao();
            try
            {
                if (UtilisateurEvenementParticipeService != null)
                {
                   var user = UtilisateurEvenementProposeService.GetUtilisateurProposeByEvenementId(eventId);
                   var userDaoList = (List<UtilisateurDao>)user.ToDaoUtilisateurs();
                   userDao = userDaoList.First();

                   if (!string.IsNullOrEmpty(userDao.Pseudo))
                   {
                        var nbAmis = UserService.NbAmisByPseudo(userDao.Pseudo);
                        var nbEventPropose = UserService.NbEvenementProposeByPseudo(userDao.Pseudo);
                        var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(userDao.Pseudo);
                        userDao.NbAmis = nbAmis.Value;
                        userDao.NbEvenementParticipe = nbEventParticipe.Value;
                        userDao.NbEvenmentPropose = nbEventPropose.Value;
                   }
                    
                }
            }
            catch (Exception ex)
            {

            }
            return userDao;
        }
        #endregion Methods
    }
}




