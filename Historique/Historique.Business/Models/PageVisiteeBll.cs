using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historique.Business.Models
{
    public class PageVisiteeBll
    {
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        private int _NbVue;

        public int NbVue
        {
            get { return _NbVue; }
            set { _NbVue = value; }
        }

        private double _TempsMoyen;

        public double TempsMoyen
        {
            get { return _TempsMoyen; }
            set { _TempsMoyen = value; }
        }
        
    }
}
