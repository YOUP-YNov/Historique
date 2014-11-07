using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historique.Models
{
    public class Categorie
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Libelle;

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }
    }
}