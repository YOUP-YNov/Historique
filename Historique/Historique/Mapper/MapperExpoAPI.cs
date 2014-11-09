using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Historique.Business.Models;
using Historique.Models;


namespace Historique.Mapper
{
    public class MapperExpoAPI
    {
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

            }
            return categorie;

        }
        public static Evenement ToEvenement(EvenementBll evenementBll)
        {
            Evenement evenement = null;
            try
            {
                AutoMapper.Mapper.CreateMap<EvenementBll, Evenement>(); //définiton du mapping
                evenement = AutoMapper.Mapper.Map<EvenementBll, Evenement>(evenementBll);//Convert
            }
            catch (Exception)
            {

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
            catch (Exception)
            {

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
                utilisateur = AutoMapper.Mapper.Map<UtilisateurBll, Utilisateur>(utilisateurBll);//Convert

            }
            catch (Exception)
            {

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
    }
}