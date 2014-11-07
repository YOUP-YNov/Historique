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
        public  CategorieDao categorieDao;
        public EvenementDao evenementDao;
        public EvenementLieuDao evenementLieuDao;
        public UtilisateurDao utilisateurDao;
        
        public void  Create()
        {
            AutoMapper.Mapper.CreateMap<CategorieDao, CategorieBll>(); //définiton du mapping
            CategorieBll categorieBll = AutoMapper.Mapper.Map<CategorieDao, CategorieBll>(categorieDao);//Convert


            AutoMapper.Mapper.CreateMap<EvenementDao, EvenementBll>(); //définiton du mapping
            EvenementBll evenementBll = AutoMapper.Mapper.Map<EvenementDao, EvenementBll>(evenementDao);//Convert

            AutoMapper.Mapper.CreateMap<EvenementLieuDao, EvenementLieuBll>(); //définiton du mapping
            EvenementLieuBll evenementLieuBll = AutoMapper.Mapper.Map<EvenementLieuDao, EvenementLieuBll>(evenementLieuDao);//Convert

            AutoMapper.Mapper.CreateMap<UtilisateurDao, UtilisateurBll>(); //définiton du mapping
            UtilisateurBll utilisateurBll = AutoMapper.Mapper.Map<UtilisateurDao, UtilisateurBll>(utilisateurDao);//Convert



            
        }
        
    }
}
