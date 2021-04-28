using Model.Business;
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
    public class DAOsalles
    {
        #region Attributs
        public Dbal _dbal;
        #endregion

        #region Constructeurs
        public DAOsalles(Dbal dbal)
        {
            _dbal = dbal;
        }
        #endregion


        #region Autres méthodes
        public void insert(salles unesalle,theme untheme)
        {
            string SalleInsert;

            SalleInsert = ("salle (idSalle, ville, idTheme) values (" + unesalle.IdSalle + ",'" + unesalle.Ville.Replace("'", "''") + "'," + untheme.IdTheme + ")");
            _dbal.Insert(SalleInsert);
        }

        public void delete(salles unesalle)
        {
            string SalleDelete;

            SalleDelete = ("salle where id ='" + unesalle.IdSalle + "'");
            _dbal.Delete(SalleDelete);
        }

        public void update(salles unesalle,theme untheme)
        {
            string SalleUpdate;

            SalleUpdate = ("salles set id ='" + unesalle.IdSalle + "' , nom = '" + unesalle.Ville.Replace("'", "''") + untheme.IdTheme + "'");
            _dbal.Update(SalleUpdate);
        }

        public List<salles> SelectAll()
        {
            List<salles> listSalles = new List<salles>();
            foreach (DataRow r in _dbal.SelectAll("salles").Rows)
            {
                listSalles.Add(new salles((int)r["idSalle"], (string)r["ville"], (theme)r["idSalle"]));
            }
            return listSalles;
        }

        public salles SelectByName(string salle)
        {
            DataRow r = _dbal.SelectByField("salles", "nom like '" + salle + "'").Rows[0];
            return new salles((int)r["idSalle"], (string)r["ville"], (theme)r["idSalle"]);
        }

        public salles SelectById(int idSalle)
        {
            DataRow r = _dbal.SelectById("salles", idSalle);
            return new salles((int)r["idSalle"], (string)r["ville"], (theme)r["idSalle"]);
        }
        #endregion
    }
}
