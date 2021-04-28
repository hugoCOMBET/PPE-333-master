using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class Clients
    {
        #region attribut privé
        private int _id;
        private string _nom;
        private string _prenom;
        private string _photo;
        private string _adresse;
        private DateTime _DateNaissance;
        private string _Email;
        private string _TelephonePortable;
        private double _credit;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public DateTime DateNaissance { get => _DateNaissance; set => _DateNaissance = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TelephonePortable { get => _TelephonePortable; set => _TelephonePortable = value; }
        public double Credit { get => _credit; set => _credit = value; }


        #endregion

        #region constructeurs
        public Clients(int UnIdClient, string UnClient, string UnPrenomClient, string UnePhotoClient, string UneAdresseClient, DateTime UneDateNaissClient, string unEmailClient, string unNumTelephoneClient,double uncredit)
        {
            _id = UnIdClient;
            _nom = UnClient;
            _prenom = UnPrenomClient;
            _photo = UnePhotoClient;
            _adresse = UneAdresseClient;
            _DateNaissance = UneDateNaissClient;
            _Email = unEmailClient;
            _TelephonePortable = unNumTelephoneClient;
            _credit = uncredit;
        }

        public Clients()
        {
            _id = 0;
            _nom = "";
            _prenom = "";
            _photo = "";
            _adresse = "";
            _DateNaissance = new DateTime();
            _Email = "";
            _TelephonePortable = "";
            _credit = 0;
        }
        #endregion

        #region getteurs/setteurs
        public int getIdClient()
        {
            return _id;
        }
        public void setIdClient(int unIdClient)
        {
            _id = unIdClient;
        }
        public string getNomClient()
        {
            return _nom;
        }
        public void setNomClient(string unNomClient)
        {
            _nom = unNomClient;
        }

        public string getPrenomClient()
        {
            return _prenom;
        }
        public void setPrenomClient(string unPrenomClient)
        {
            _prenom = unPrenomClient;
        }

        public string getPhotoClient()
        {
            return _photo;
        }
        public void setPhotoClient(string unePhotoClient)
        {
            _photo = unePhotoClient;
        }

        public string getAdresseClient()
        {
            return _adresse;
        }
        public void setAdresseClient(string uneAdresseClient)
        {
            _adresse = uneAdresseClient;
        }

        public DateTime getDateNaissanceClient()
        {
            return _DateNaissance;
        }
        public void setDateNaissanceClient(DateTime uneDateNaissClient)
        {
            _DateNaissance = uneDateNaissClient;
        }

        public string getEmailClient()
        {
            return _Email;
        }
        public void setEmailClient(string unEmailClient)
        {
            _Email = unEmailClient;
        }

        public string getTelPortableCLient()
        {
            return _TelephonePortable;
        }
        public void setTelPortableCLient(string unTelPortableClient)
        {
            _TelephonePortable = unTelPortableClient;
        }

        public double getCreditClient()
        {
            return _credit;
        }
        public void setCreditClient(double uncredit)
        {
            _credit = uncredit;
        }
        #endregion

        public override string ToString()
        {
            return this.getNomClient() + "  " + this.getPrenomClient();
        }
    }
}
