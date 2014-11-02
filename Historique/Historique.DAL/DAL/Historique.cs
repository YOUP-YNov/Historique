using System;
using System.Collections.Generic;
using System.Linq;
using Historique.DAL.DAO;

namespace Historique.DAL.DAL
{
    public partial class Historique
    {
        #region Properties

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

        #endregion Properties

        #region Methods

        public IEnumerable<CategorieDao> GetAllCategorie()
        {
            var catDaoList = new List<CategorieDao>();
            try
            {
                var cat = CategorieService.GetData();
                catDaoList = (List<CategorieDao>)cat.ToDaoCategories();
            }
            catch (Exception ex)
            {
                throw;
            }
            return catDaoList;
        }

        public IEnumerable<UtilisateurDao> GetAllUser()
        {
            var userDaoList = new List<UtilisateurDao>();
            try
            {
                var users = UserService.GetData();
                userDaoList = (List<UtilisateurDao>)users.ToDaoUtilisateurs();

                foreach (var user in userDaoList)
                {
                    if(!string.IsNullOrEmpty(user.Pseudo))
                    {
                        var nbAmis = UserService.NbAmisByPseudo(user.Pseudo);
                        var nbEventPropose = UserService.NbEvenementProposeByPseudo(user.Pseudo);
                        var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(user.Pseudo);
                        user.NbAmis = nbAmis.Value;
                        user.NbEvenementParticipe = nbEventParticipe.Value;
                        user.NbEvenmentPropose = nbEventPropose.Value;
                    }
                    user.EvenementsParticipes = GetEvenementParticipeByUserId(user.Id);
                }

            }
            catch (Exception ex)
            {                
                throw;
            }
            return userDaoList;
        }

        public UtilisateurDao GetUserById(int id)
        {
            var userDao = new UtilisateurDao();
            try
            {
                var nbAmis = UserService.NbAmis(id);
                var nbEventPropose = Convert.ToInt32(UserService.NbEvenementPropose(id));
                var nbEventParticipe = Convert.ToInt32(UserService.NbEvenementParticipe(id));

                var result = UserService.GetDataById(id);
                List<UtilisateurDao> userDaoList = (List<UtilisateurDao>)result.ToDaoUtilisateurs();
                userDao = userDaoList.First();

                userDao.NbAmis = nbAmis.Value;
                userDao.NbEvenementParticipe = nbEventParticipe;
                userDao.NbEvenmentPropose = nbEventPropose;
            }
            catch (Exception ex)
            {                
                throw;
            }
            return userDao;
        }

        public UtilisateurDao GetUserByPseudo(string pseudo)
        {
            var userDao = new UtilisateurDao();

            if (string.IsNullOrEmpty(pseudo))
                return null;
            try
            {
                var nbAmis = UserService.NbAmisByPseudo(pseudo);
                var nbEventPropose = UserService.NbEvenementProposeByPseudo(pseudo);
                var nbEventParticipe = UserService.NbEvenementParticipeByPseudo(pseudo);

                var result = UserService.GetDataByPseudo(pseudo);
                List<UtilisateurDao> userDaoList = (List<UtilisateurDao>)result.ToDaoUtilisateurs();
                userDao = userDaoList.First();

                userDao.NbAmis = nbAmis.Value;
                userDao.NbEvenementParticipe = nbEventParticipe.Value;
                userDao.NbEvenmentPropose = nbEventPropose.Value;
            }
            catch (Exception ex)
            {              
                throw;
            }
            return userDao;
        }

        public IEnumerable<EvenementDao> GetAllEvenement()
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                var evenement = EvenementService.GetData();
                eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
                foreach (var eventDao in eventDaoList)
                {
                    eventDao.Participants = GetUtilisateurParticipeByEvenementId(eventDao.Id);   
                }
            }
            catch (Exception ex)
            {                
                throw;
            }
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByCateByCp(int codePostale, string categorie)
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                var evenement = EvenementService.GetDataByCateByCp(codePostale, categorie);
                eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
            }
            catch(Exception ex)
            {

            }
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementByCp(int codePostale)
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                var evenement = EvenementService.GetDataByCp(codePostale);
                eventDaoList = (List<EvenementDao>)evenement.ToDaoEvenements();
                foreach (var eventDao in eventDaoList)
                {
                    eventDao.Participants = GetUtilisateurParticipeByEvenementId(eventDao.Id);
                }
            }
            catch(Exception ex)
            {

            }
            return eventDaoList;
        }

        public IEnumerable<EvenementDao> GetEvenementParticipeByUserId(int userId)
        {
            var eventDaoList = new List<EvenementDao>();
            try
            {
                if(UtilisateurEvenementParticipeService!=null)
                {
                    var evenement = UtilisateurEvenementParticipeService.GetEvenementParticipeByUserId(userId);
                    foreach (var eventDao in eventDaoList)
                    {
                        eventDao.Participants = GetUtilisateurParticipeByEvenementId(eventDao.Id);
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
                    var user = UtilisateurEvenementParticipeService.GetUtilisateurByEvenenementId(eventId);
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

        #endregion Methods
    }
}