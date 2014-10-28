namespace Historique.DAL.DAO
{
    public class EvenementLieuDao
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
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

        private string _Pays;

        public string Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }

        private double _Longitude;

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        private double _Latitute;

        public double Latitute
        {
            get { return _Latitute; }
            set { _Latitute = value; }
        }
    }
}