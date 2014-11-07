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
        public CategorieBll categorieBll;
        public EvenementBll evenementBll;
        public EvenementLieuBll evenementLieuBll;
        public UtilisateurBll utilisateurBll;



        public void CreateMapperBll()
        {
            AutoMapper.Mapper.CreateMap<CategorieBll,Categorie>(); //définiton du mapping
            Categorie categorie = AutoMapper.Mapper.Map<CategorieBll, Categorie>(categorieBll);

            //      CategorieBll categorieBll = AutoMapper.Mapper.Map<CategorieDao, CategorieBll>(categorieDao);//Convert
     
        }


    }
}