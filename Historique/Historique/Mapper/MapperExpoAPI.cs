using System;
using System.Collections.Generic;
using Historique.Business.Models;
using Historique.Models;
using Logger;

namespace Historique.Mapper
{
    public class MapperExpoAPI
    {

       private static string urlLogger = "http://loggerasp.azurewebsites.net/";

        //To ExpoApi
        public static Categorie ToCategorie(CategorieBll categorieBll)
        {
            
            Categorie categorie = null;
            try
            {
                AutoMapper.Mapper.CreateMap<CategorieBll, Categorie>(); //définiton du mapping
                categorie = AutoMapper.Mapper.Map<CategorieBll, Categorie>(categorieBll);
            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.MapperExpoAPI.ToCategorie").Save(urlLogger);

            }
            return categorie;

        }
        public static Evenement ToEvenement(EvenementBll evenementBll)
        {
            Evenement evenement = null;
            try
            {
                AutoMapper.Mapper.CreateMap<EvenementBll, Evenement>(); //définiton du mapping
                evenement = AutoMapper.Mapper.DynamicMap<EvenementBll, Evenement>(evenementBll);//Convert
            }
            catch (Exception ex)
            {

                new LErreur(ex, "Historique", "Mapper.MapperExpoAPI.ToEvenement").Save(urlLogger);
                throw;
            }
            return evenement;
        }
        public static EvenementLieu ToEvenementLieu(EvenementLieuBll evenementLieuBll)
        {
            EvenementLieu evenementLieu = null;
            try
            {
                AutoMapper.Mapper.CreateMap<EvenementLieuBll, EvenementLieu>(); //définiton du mapping
                evenementLieu = AutoMapper.Mapper.Map<EvenementLieuBll, EvenementLieu>(evenementLieuBll);

            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.MapperExpoAPI.ToEvenementLieu").Save(urlLogger);
                throw;
            }
            return evenementLieu;
        }
        public static Utilisateur ToUtilisateur(UtilisateurBll utilisateurBll)
        {
            Utilisateur utilisateur = null;
            try
            {
                AutoMapper.Mapper.CreateMap<UtilisateurBll, Utilisateur>(); //définiton du mapping
                utilisateur = AutoMapper.Mapper.DynamicMap<UtilisateurBll, Utilisateur>(utilisateurBll);//Convert

            }
            catch (Exception ex)
            {
                new LErreur(ex, "Historique", "Mapper.MapperExpoAPI.ToUtilisateur").Save(urlLogger);
                throw;
            }
            return utilisateur;

        }

        // To ExpoApi list
        public static List<Categorie> ToCategories(List<CategorieBll> listeCategoriesBll)
        {
            List<Categorie> listeCategories = new List<Categorie>();

            foreach (var categorieBll in listeCategoriesBll)
            {
                var categorie = ToCategorie(categorieBll);
                if(categorie!=null)
                    listeCategories.Add(categorie);
            
            }
            return listeCategories;
        }

        public static List<Evenement> ToEvenements(List<EvenementBll> listeEventementsBll)
        {
            List<Evenement> listeEvenements = new List<Evenement>();

            foreach (var evenementBll in listeEventementsBll)
            {
                var evenement = ToEvenement(evenementBll);
                if(evenement!=null)
                    listeEvenements.Add(evenement);
            }
            return listeEvenements;
        }

        public static List<EvenementLieu> ToEvenementsLieux(List<EvenementLieuBll> listeEventementsLieuxBll)
        {
            List<EvenementLieu> listeEvenementsLieux = new List<EvenementLieu>();

            foreach (var evenementLieuBll in listeEventementsLieuxBll)
            {
                var evenement = ToEvenementLieu(evenementLieuBll);
                if(evenement!=null)
                    listeEvenementsLieux.Add(evenement);
            }
            return listeEvenementsLieux;
        }

        public static List<Utilisateur> ToUtilisateurs(List<UtilisateurBll> listeUtilisateursBll)
        {
            List<Utilisateur> listesUtilisateurs = new List<Utilisateur>();

            foreach (var utilisateurBll in listeUtilisateursBll)
            {
                var utilisateur = ToUtilisateur(utilisateurBll);
                if(utilisateur != null)
                    listesUtilisateurs.Add(utilisateur);

            }
            return listesUtilisateurs;
        }

        public static PageVisitee ToPageVisitee(PageVisiteeBll pageVisiteeBll)
        {
            PageVisitee pageVisitee = new PageVisitee();

            try
            {
                AutoMapper.Mapper.CreateMap<PageVisiteeBll, PageVisitee>();
                pageVisitee = AutoMapper.Mapper.Map<PageVisiteeBll, PageVisitee>(pageVisiteeBll);
            }
            catch (Exception exception)
            {
                
            }

            return pageVisitee;
        }

        public static List<PageVisitee> ToPageVisitees(List<PageVisiteeBll> pageVisiteesBll)
        {
            List<PageVisitee> pageVisitees = new List<PageVisitee>();

            foreach (var pageVisiteeBll in pageVisiteesBll)
            {
                var pageVisitee = ToPageVisitee(pageVisiteeBll);
                if (pageVisitee != null)
                {
                    pageVisitees.Add(pageVisitee);
                }
            }

            return pageVisitees;
        }
    }
}