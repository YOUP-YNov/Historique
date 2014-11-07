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
            AutoMapper.Mapper.CreateMap<CategorieBll, Categorie>(); //définiton du mapping
            return AutoMapper.Mapper.Map<CategorieBll, Categorie>(categorieBll);//Convert

        }
        public static Evenement ToEvenement(EvenementBll evenementBll)
        {
            AutoMapper.Mapper.CreateMap<EvenementBll, Evenement>(); //définiton du mapping
            return AutoMapper.Mapper.Map<EvenementBll, Evenement>(evenementBll);//Convert

        }
        public static EvenementLieu ToEvenementLieu(EvenementLieuBll evenementLieuBll)
        {
            AutoMapper.Mapper.CreateMap<EvenementLieuBll, EvenementLieu>(); //définiton du mapping
            return AutoMapper.Mapper.Map<EvenementLieuBll, EvenementLieu>(evenementLieuBll);//Convert
        }
        public static Utilisateur ToUtilisateur(UtilisateurBll utilisateurBll)
        {
            AutoMapper.Mapper.CreateMap<UtilisateurBll, Utilisateur>(); //définiton du mapping
            return AutoMapper.Mapper.Map<UtilisateurBll, Utilisateur>(utilisateurBll);//Convert
        }

        // To ExpoApi list
        public static List<Categorie> ToCategories(List<CategorieBll> listeCategoriesBll)
        {
            List<Categorie> listeCategories = new List<Categorie>();

            foreach (var categorie in listeCategoriesBll)
            {
                listeCategories.Add(ToCategorie(categorie));
            
            }
            return listeCategories;
        }

        public static List<Evenement> ToEvenements(List<EvenementBll> listeEventementsBll)
        {
            List<Evenement> listeEvenements = new List<Evenement>();

            foreach (var evenement in listeEventementsBll)
            {
                listeEvenements.Add(ToEvenement(evenement));

            }
            return listeEvenements;
        }

        public static List<EvenementLieu> ToEvenementsLieux(List<EvenementLieuBll> listeEventementsLieuxBll)
        {
            List<EvenementLieu> listeEvenementsLieux = new List<EvenementLieu>();

            foreach (var evenementLieu in listeEventementsLieuxBll)
            {
                listeEvenementsLieux.Add(ToEvenementLieu(evenementLieu));

            }
            return listeEvenementsLieux;
        }

        public static List<Utilisateur> ToUtilisateurs(List<UtilisateurBll> listeUtilisateursBll)
        {
            List<Utilisateur> listesUtilisateurs = new List<Utilisateur>();

            foreach (var utilisateur in listeUtilisateursBll)
            {
                listesUtilisateurs.Add(ToUtilisateur(utilisateur));

            }
            return listesUtilisateurs;
        }
    }
}