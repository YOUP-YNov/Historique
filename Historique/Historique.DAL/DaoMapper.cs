using Historique.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Historique.DAL
{
    public static class DaoMapper
    {
        public static UtilisateurDao ToDaoUtilisateur(this Historique.DAL.DAL.Historique.UT_UtilisateurRow userRow)
        {
            var userDao = new UtilisateurDao();
            userDao.Pseudo = userRow.Pseudo;
            userDao.CheminPhoto = userRow.PhotoChemin;
            userDao.Age = (DateTime.Now - userRow.DateNaissance).Days;
            return userDao;
        }


        public static IEnumerable<UtilisateurDao> ToDaoUtilisateurs(this Historique.DAL.DAL.Historique.UT_UtilisateurDataTable userTable)
        {
            if (userTable == null && userTable.Rows == null)
                return null;

            List<UtilisateurDao> result = new List<UtilisateurDao>();

            foreach (Historique.DAL.DAL.Historique.UT_UtilisateurRow userRow in userTable)
            {
                UtilisateurDao daoResult = userRow.ToDaoUtilisateur();
                if (daoResult != null)
                    result.Add(daoResult);
            }

            return result;
        }      
    }
}
