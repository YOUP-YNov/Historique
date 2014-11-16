using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Historique.Models;

namespace Historique.Mapper
{
    public interface IHistoriqueApiService
    {
        IEnumerable<Categorie> GetAllCategorieBll();

        IEnumerable<Utilisateur> GetAllUser();

        Utilisateur GetUserById(int id);

        Utilisateur GetUserByPseudo(string pseudo);

        IEnumerable<Evenement> GetAllEvenement();

        IEnumerable<Evenement> GetEvenementByCateByCp(int codePostale, string categorie);

        IEnumerable<Evenement> GetEvenementByCp(int codePostale);

        IEnumerable<Evenement> GetEvenementByCat(string categorie, DateTime dateDebut, DateTime dateFin);

        IEnumerable<Evenement> GetEvenementByDates(DateTime dateDebut, DateTime dateFin);

        IEnumerable<Evenement> GetEvenementParticipeByUserId(int userId);

        IEnumerable<Utilisateur> GetUtilisateurParticipeByEvenementId(int eventId);

        IEnumerable<Evenement> GetEvenementProposeByUserId(int userId);

        Utilisateur GetUtilisateurProposeByEvenementId(int eventId);
    }
}
