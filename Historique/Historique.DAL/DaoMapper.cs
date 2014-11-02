using System;
using System.Collections.Generic;
using Historique.DAL.DAO;

namespace Historique.DAL
{
    public static class DaoMapper
    {
        public static UtilisateurDao ToDaoUtilisateur(this Historique.DAL.DAL.Historique.UT_UtilisateurRow userRow)
        {
            var userDao = new UtilisateurDao();
            userDao.Id = Convert.ToInt32(userRow.Utilisateur_id);
            userDao.Pseudo = userRow.Pseudo;
            userDao.DateInscription = userRow.DateInscription;
            userDao.CodePostale = userRow.CodePostal;
            userDao.Ville = userRow.Ville;
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

        public static EvenementDao ToDaoEvenement(this Historique.DAL.DAL.Historique.ps_GetAllEvenementRow eventRow)
        {
            var eventDao = new EvenementDao();
            eventDao.Id = Convert.ToInt32(eventRow.Evenement_id);
            eventDao.IdUser = Convert.ToInt32(eventRow.Utilisateur_id);
            eventDao.Titre = eventRow.TitreEvenement;
            eventDao.Categorie.Libelle = eventRow.Libelle;
            eventDao.Categorie.Id = Convert.ToInt32(eventRow.Categorie_id);
            eventDao.DateEvenement = eventRow.DateEvenement;
            eventDao.DateFinIncription = eventRow.DateFinInscription;
            eventDao.DateModification = eventRow.DateModification;
            eventDao.Description = eventRow.DescriptionEvenement;
            eventDao.Etat = eventRow.StateName;
            eventDao.NbMaxParticipant = eventRow.MaximumParticipant;
            eventDao.NbMinParticipant = eventRow.MinimumParticipant;
            eventDao.Premium = eventRow.Premium;
            eventDao.Prix = Convert.ToDouble(eventRow.Prix);
            eventDao.Statut = eventRow.Statut;
            eventDao.Lieu.Id = Convert.ToInt32(eventRow.LieuEvenement_id);
            eventDao.Lieu.Latitute = Convert.ToDouble(eventRow.Latitude);
            eventDao.Lieu.Longitude = Convert.ToDouble(eventRow.Longitude);
            eventDao.Lieu.Pays = eventRow.Pays;
            eventDao.Lieu.Ville = eventRow.Ville;
            return eventDao;
        }

        public static IEnumerable<EvenementDao> ToDaoEvenements(this Historique.DAL.DAL.Historique.ps_GetAllEvenementDataTable eventTable)
        {
            if (eventTable == null && eventTable.Rows == null)
                return null;

            List<EvenementDao> result = new List<EvenementDao>();

            foreach (Historique.DAL.DAL.Historique.ps_GetAllEvenementRow eventRow in eventTable)
            {
                EvenementDao daoResult = eventRow.ToDaoEvenement();
                if (daoResult != null)
                    result.Add(daoResult);
            }

            return result;
        }

        public static CategorieDao ToDaoCategorie(this Historique.DAL.DAL.Historique.UT_CategorieRow catRow)
        {
            var catDao = new CategorieDao();
            catDao.Id = Convert.ToInt32(catRow.Categorie_id);
            catDao.Libelle = catRow.Libelle;
            return catDao;
        }

        public static IEnumerable<CategorieDao> ToDaoCategories(this Historique.DAL.DAL.Historique.UT_CategorieDataTable catTable)
        {
            if (catTable == null && catTable.Rows == null)
                return null;

            List<CategorieDao> result = new List<CategorieDao>();

            foreach (Historique.DAL.DAL.Historique.UT_CategorieRow catRow in catTable)
            {
                CategorieDao daoResult = catRow.ToDaoCategorie();
                if (daoResult != null)
                    result.Add(daoResult);
            }

            return result;
        }
    }
}