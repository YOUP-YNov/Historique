using System;
using System.Collections.Generic;
using Historique.DAL.DAO;

namespace Historique.DAL.DAL
{
    public interface IHistorique
    {
        IEnumerable<CategorieDao> GetAllCategorie();

        IEnumerable<UtilisateurDao> GetAllUser();

        UtilisateurDao GetUserById(int id);

        UtilisateurDao GetUserByPseudo(string pseudo);

        IEnumerable<EvenementDao> GetAllEvenement();

        IEnumerable<EvenementDao> GetEvenementByCateByCp(int codePostale, string categorie);

        IEnumerable<EvenementDao> GetEvenementByCp(int codePostale);

        IEnumerable<EvenementDao> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin);

        IEnumerable<EvenementDao> GetEvenementByDates(DateTime dateDebut, DateTime dateFin);

        IEnumerable<EvenementDao> GetEvenementParticipeByUserId(int userId);

        IEnumerable<UtilisateurDao> GetUtilisateurParticipeByEvenementId(int eventId);

        IEnumerable<EvenementDao> GetEvenementProposeByUserId(int userId);

        UtilisateurDao GetUtilisateurProposeByEvenementId(int eventId);
    }
}