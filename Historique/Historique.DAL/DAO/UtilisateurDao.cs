using System;
using System.Collections.Generic;

namespace Historique.DAL.DAO
{
    public class UtilisateurDao
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private bool _IsHomme;

        public bool IsHomme
        {
            get { return _IsHomme; }
            set { _IsHomme = value; }
        }

        private string _Pseudo;

        public string Pseudo
        {
            get { return _Pseudo; }
            set { _Pseudo = value; }
        }

        private string _Metier;

        public string Metier
        {
            get { return _Metier; }
            set { _Metier = value; }
        }

        private DateTime _DateInscription;

        public DateTime DateInscription
        {
            get { return _DateInscription; }
            set { _DateInscription = value; }
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

        private string _Ville;

        public string Ville
        {
            get { return _Ville; }
            set { _Ville = value; }
        }

        private string _CodePostale;

        public string CodePostale
        {
            get { return _CodePostale; }
            set { _CodePostale = value; }
        }

        private IEnumerable<EvenementDao> _EvenementsParticipes;

        public IEnumerable<EvenementDao> EvenementsParticipes
        {
            get 
            {
                if (_EvenementsParticipes == null)
                    _EvenementsParticipes = new List<EvenementDao>();
                return _EvenementsParticipes; 
            }
            set { _EvenementsParticipes = value; }
        }

        private IEnumerable<EvenementDao> _EvenementsCrees;

        public IEnumerable<EvenementDao> EvenementsCrees
        {
            get 
            {
                if (_EvenementsCrees == null)
                    _EvenementsCrees = new List<EvenementDao>();
                return _EvenementsCrees; 
            }
            set { _EvenementsCrees = value; }
        }
    }

}