using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historique.DAL.DAO
{
    public class UtilisateurDao
    {
        private string _Pseudo;

        public string Pseudo
        {
            get { return _Pseudo; }
            set { _Pseudo = value; }
        }

        private string _CheminPhoto;

        public string CheminPhoto
        {
            get { return _CheminPhoto; }
            set { _CheminPhoto = value; }
        }

        private int _Age;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        

        private int _NbAmis;

        public int NbAmis
        {
            get { return _NbAmis; }
            set { _NbAmis = value; }
        }

        private int _NbEvenementPropose;

        public int NbEvenmentPropose
        {
            get { return _NbEvenementPropose; }
            set { _NbEvenementPropose = value; }
        }

        private int _NbEvenementParticipe;

        public int NbEvenementParticipe
        {
            get { return _NbEvenementParticipe; }
            set { _NbEvenementParticipe = value; }
        }
        
        
    }
}
