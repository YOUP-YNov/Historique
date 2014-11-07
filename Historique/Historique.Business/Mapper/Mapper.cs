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
             AutoMapper.Mapper.CreateMap<CategorieDao, CategorieBll>(); //définiton du mapping
             return AutoMapper.Mapper.Map<CategorieDao, CategorieBll>(categorieDao);//Convert
        
        }

        public static EvenementBll ToEvenementBll(EvenementDao evenementDao)
        {
            AutoMapper.Mapper.CreateMap<EvenementDao, EvenementBll>(); //définiton du mapping
            return AutoMapper.Mapper.Map<EvenementDao, EvenementBll>(evenementDao);//Convert

        }


        public static EvenementLieuBll ToEvenementLieuBll(EvenementLieuDao evenementLieuDao)
        {
            AutoMapper.Mapper.CreateMap<EvenementLieuDao, EvenementLieuBll>(); //définiton du mapping
            return AutoMapper.Mapper.Map<EvenementLieuDao, EvenementLieuBll>(evenementLieuDao);//Convert

        }

        public static UtilisateurBll ToUtilisateurBll(UtilisateurDao utilisateurDao)
        {
            AutoMapper.Mapper.CreateMap<UtilisateurDao, UtilisateurBll>(); //définiton du mapping
            return AutoMapper.Mapper.Map<UtilisateurDao, UtilisateurBll>(utilisateurDao);//Convert
        }
        
        
        // To business list
        public static List<CategorieBll> ToCategoriesSBll(List<CategorieDao> listeCategorieDao)
        {
            List<CategorieBll> listeCategorieBll = new List<CategorieBll>();

            foreach (var categorieBll in listeCategorieDao)
            {
                listeCategorieBll.Add(ToCategorieBll(categorieBll));
            }
            return listeCategorieBll;
        }
    
        public static List<EvenementBll> ToEvenementsBll(List<EvenementDao>listeEvenementDao)
        {
            List<EvenementBll> listeEvenementBll = new List<EvenementBll>();
             
            foreach (var evenementBll in listeEvenementDao)
            {
                listeEvenementBll.Add(ToEvenementBll(evenementBll));
            }
            return listeEvenementBll;

        }
        
        
        public static List<EvenementLieuBll> ToEvenementsLieuBll(List<EvenementLieuDao>listeEvenementLieuDao)
        {
            List<EvenementLieuBll> listeEvenementLieuBll = new List<EvenementLieuBll>();

            foreach (var evenementLieuBll in listeEvenementLieuDao)
            {
                listeEvenementLieuBll.Add(ToEvenementLieuBll(evenementLieuBll));
            }
            return listeEvenementLieuBll;

        }

        public static List<UtilisateurBll> ToUtilisateursBll(List<UtilisateurDao>listeUtilisateurDao)
        {
            List<UtilisateurBll> listeUtilisateurBll = new List<UtilisateurBll>();

            foreach (var utilisateurBll in listeUtilisateurDao)
            {
                listeUtilisateurBll.Add(ToUtilisateurBll(utilisateurBll));
            }
            return listeUtilisateurBll;
           

        }


    }
}
