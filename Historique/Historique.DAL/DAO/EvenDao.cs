using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historique.DAL.DAO
{
    class EvenDao
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _IdUser;

        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private DateTime _EveDateDebut;

        public DateTime EveDateDebut
        {
            get { return _EveDateDebut; }
            set { _EveDateDebut = value; }
        }

        private DateTime _EveDateCreation;

        public DateTime EveDateCreation
        {
            get { return _EveDateCreation; }
            set { _EveDateCreation = value; }
        }

        private DateTime _EveDateModification;
        public DateTime EveDateModification
        {
            get { return _EveDateModification; }
            set { _EveDateModification = value; }
        }

        private DateTime _EveDateFinIsncription;
        public DateTime EveDateFinIsncription
        {
            get { return _EveDateFinIsncription; }
            set { _EveDateFinIsncription = value; }
        }

        private string _EveTitre;
        public string EveTitre
        {
            get { return _EveTitre; }
            set { _EveTitre = value; }
        }

        private string _EveDescription;
        public string EveDescription
        {
            get { return _EveDescription; }
            set { _EveDescription = value; }
        }

        private int _EveMinParticipants;
        public int EveMinParticipants
        {
            get { return _EveMinParticipants; }
            set { _EveMinParticipants = value; }
        }

        private int _EveMaxParticipants;
        public int EveMaxParticipants
        {
            get { return _EveMaxParticipants; }
            set { _EveMaxParticipants = value; }
        }

        private string _EveStatut;
        public string EveStatut
        {
            get { return _EveStatut; }
            set { _EveStatut = value; }
        }

        private double _EvePrix;
        public double EvePrix
        {
            get { return _EvePrix; }
            set { _EvePrix = value; }
        }
        private CategorieDao _Categorie;

        public CategorieDao Categorie
        {
            get
            {
                if (_Categorie == null)
                    _Categorie = new CategorieDao();
                return _Categorie;
            }
            set { _Categorie = value; }
        }

        private EvenementLieuDao _Lieu;

        public EvenementLieuDao Lieu
        {
            get
            {
                if (_Lieu == null)
                    _Lieu = new EvenementLieuDao();
                return _Lieu;
            }
            set
            {
                _Lieu = value;
            }
        }
    }
}
