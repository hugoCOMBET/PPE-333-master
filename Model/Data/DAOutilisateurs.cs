using CsvHelper;
using Model.Business;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class DAOutilisateurs
    {
        private Dbal _dbal;

        public DAOutilisateurs(Dbal dbal)
        {
            _dbal = dbal;
        }

        public void Insert(Utilisateurs unUtilisateur)
        {
            string query = " Utilisateur VALUES " + "(" + unUtilisateur.getLogin() 
                + ",'" + unUtilisateur.getMotDePasse().Replace("'", "''");
            this._dbal.Insert(query);
        }
        public void Update(Utilisateurs unUtilisateur)
        {
            string query = "Utilisateur SET Login = " + unUtilisateur.getLogin().Replace("'", "''")
                + ", MotDePasse = '" + unUtilisateur.getMotDePasse().Replace("'", "''")
                + "' WHERE Login = " + unUtilisateur.getLogin();
            this._dbal.Update(query);
        }

        public void Delete(Utilisateurs unUtilisateur)
        {
            string query = "Utilisateur WHERE Login = " + unUtilisateur.getLogin() + ";";
            this._dbal.Delete(query);
        }

        public List<Utilisateurs> SelectAll()
        {
            List<Utilisateurs> listeAll = new List<Utilisateurs>();
            foreach (DataRow r in _dbal.SelectAll("Utilisateur").Rows)
            {
                listeAll.Add(new Utilisateurs
                    ((string)r["Login"],
                    (string)r["MotDePasse"]));
            }
            return listeAll;
        }
        public Utilisateurs SelectByName(string login)
        {
            DataRow r = _dbal.SelectByField("Utilisateur", "Login like '" + login + "'").Rows[0];
            return new Utilisateurs
                ((string)r["Login"],
                (string)r["MotDePasse"]);
        }
        public Utilisateurs SelectById(int id)
        {
            DataRow r = _dbal.SelectById("Utilisateur", id);
            return new Utilisateurs
                ((string)r["Login"],
                (string)r["MotDePasse"]);
        }
    }
}
