namespace Historique.DAL.DAO
{
    public class CategorieDao
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