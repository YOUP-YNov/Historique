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

            userDao.NbAmis = nbAmis.Value;
            userDao.NbEvenementParticipe = nbEventParticipe.Value;
            userDao.NbEvenmentPropose = nbEventPropose.Value;
            return userDao;
        }

        public IEnumerable<EvenementDao> GetAllEvenement()
        {
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

        public IEnumerable<EvenDao> GetEvenementByCat (string categorie, DateTime dateDebut, DateTime dateFin)
        {
            var evenement = EveCat.GetDataByCat(categorie, dateDebut, dateFin);
            List<EvenDao> eventDaoList = (List<EvenDao>)evenement.ToDaoEven();
            return eventDaoList;
        }
       
        #endregion Methods
    }
}


