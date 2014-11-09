using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Historique.Business.Models;
using Historique.DAL.DAO;


namespace Historique.Business.Mapper
{
    public class Mapper
    {
        //To Business
        public static CategorieBll ToCategorieBll(CategorieDao categorieDao)
        {
            CategorieBll categorie = null;
            try
            {
                AutoMapper.Mapper.CreateMap<CategorieDao, CategorieBll>(); //définiton du mapping
                categorie = AutoMapper.Mapper.Map<CategorieDao, CategorieBll>(categorieDao);//Convert
            }
            catch(Exception ex)
            {

            }
            return categorie;
        }

        public static EvenementBll ToEvenementBll(EvenementDao evenementDao)
        {
            EvenementBll evenement = null;
            try
            {
                AutoMapper.Mapper.CreateMap<EvenementDao, EvenementBll>(); //définiton du mapping
                evenement= AutoMapper.Mapper.Map<EvenementDao, EvenementBll>(evenementDao);//Convert
            }
            catch (Exception)
            {
                
                throw;
            }
            return evenement;

        }


        public static EvenementLieuBll ToEvenementLieuBll(EvenementLieuDao evenementLieuDao)
        {
            EvenementLieuBll evenementLieu = null;
            try
            {
                AutoMapper.Mapper.CreateMap<EvenementLieuDao, EvenementLieuBll>(); //définiton du mapping
                evenementLieu=  AutoMapper.Mapper.Map<EvenementLieuDao, EvenementLieuBll>(evenementLieuDao);//Convert

            }
            catch (Exception)
            {
                
                throw;
            }
            return evenementLieu;

        }

        public static UtilisateurBll ToUtilisateurBll(UtilisateurDao utilisateurDao)
        {
            UtilisateurBll utilisateur = null;
            try
            {
                AutoMapper.Mapper.CreateMap<UtilisateurDao, UtilisateurBll>(); //définiton du mapping
                utilisateur= AutoMapper.Mapper.Map<UtilisateurDao, UtilisateurBll>(utilisateurDao);//Convert

            }
            catch (Exception)
            {
                
                throw;
            }
            return utilisateur;
        }
        
        
        // To business list
        public static List<CategorieBll> ToCategoriesSBll(List<CategorieDao> listeCategorieDao)
        {
            List<CategorieBll> listeCategorieBll = new List<CategorieBll>();

            foreach (var categorieBll in listeCategorieDao)
            {
                var categorie = ToCategorieBll(categorieBll);
                if(categorie !=null)
                    listeCategorieBll.Add(categorie);
            }
            return listeCategorieBll;
        }
    
        public static List<EvenementBll> ToEvenementsBll(List<EvenementDao>listeEvenementDao)
        {
            List<EvenementBll> listeEvenementBll = new List<EvenementBll>();
             
            foreach (var evenementBll in listeEvenementDao)
            {
                var evenement = ToEvenementBll(evenementBll);    
                if(evenement!=null)
                    listeEvenementBll.Add(evenement);
            }
            return listeEvenementBll;

        }
        
        
        public static List<EvenementLieuBll> ToEvenementsLieuBll(List<EvenementLieuDao>listeEvenementLieuDao)
        {
            List<EvenementLieuBll> listeEvenementLieuBll = new List<EvenementLieuBll>();

            foreach (var evenementLieuBll in listeEvenementLieuDao)
            {
                var evenementLieu = ToEvenementLieuBll(evenementLieuBll);
                if(evenementLieu!=null)
                    listeEvenementLieuBll.Add(evenementLieu);
            }
            return listeEvenementLieuBll;

        }

        public static List<UtilisateurBll> ToUtilisateursBll(List<UtilisateurDao>listeUtilisateurDao)
        {
            List<UtilisateurBll> listeUtilisateurBll = new List<UtilisateurBll>();

            foreach (var utilisateurBll in listeUtilisateurDao)
            {
                var utilisateur = ToUtilisateurBll(utilisateurBll);
                if(utilisateur!=null)
                    listeUtilisateurBll.Add(utilisateur);
            }
            return listeUtilisateurBll;
           

        }


    }
}
