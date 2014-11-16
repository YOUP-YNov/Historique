using System;
using System.Collections.Generic;
using Historique.Business.Models;

namespace Historique.Business.Mapper
{
    public interface IHistoriqueBll
    {
        IEnumerable<CategorieBll> GetAllCategorieBll();

        IEnumerable<UtilisateurBll> GetAllUser();

        UtilisateurBll GetUserById(int id);

        UtilisateurBll GetUserByPseudo(string pseudo);

        IEnumerable<EvenementBll> GetAllEvenement();

        IEnumerable<EvenementBll> GetEvenementByCateByCp(int codePostale, string categorie);

        IEnumerable<EvenementBll> GetEvenementByCp(int codePostale);

        IEnumerable<EvenementBll> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin);

        IEnumerable<EvenementBll> GetEvenementByDates(DateTime dateDebut, DateTime dateFin);

        IEnumerable<EvenementBll> GetEvenementParticipeByUserId(int userId);

        IEnumerable<UtilisateurBll> GetUtilisateurParticipeByEvenementId(int eventId);

        IEnumerable<EvenementBll> GetEvenementProposeByUserId(int userId);

        UtilisateurBll GetUtilisateurProposeByEvenementId(int eventId);
    }
}