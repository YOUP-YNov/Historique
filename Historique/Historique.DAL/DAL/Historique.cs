
using Historique.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Historique.DAL.DAL {
    
    
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

        #endregion

        #region Methods
        public UtilisateurDao GetUserById(int id)
        {
            var nbAmis= UserService.NbAmis(id);
            var nbEventPropose = Convert.ToInt32(UserService.NbEvenementPropose(id));
            var nbEventParticipe = Convert.ToInt32(UserService.NbEvenementParticipe(id));

            var result = UserService.GetDataById(id);
            List<UtilisateurDao> userDaoList =(List<UtilisateurDao>)result.ToDaoUtilisateurs();
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
        #endregion
    }
}



