using CsvHelper;
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
    public class DAOtheme
    {
        #region Attributs
        private Dbal _dbal;
        #endregion

        #region contructeurs
        public DAOtheme(Dbal dbal)
        {
            _dbal = dbal;
        }
        #endregion

        #region Autres méthodes
        public void insert(theme untheme)
        {
            string ThemeInsert;

            ThemeInsert = ("themes (id, theme) values (" + untheme.IdTheme + ",'" + untheme.Theme.Replace("'", "''") + "')");
            _dbal.Insert(ThemeInsert);
        }

        public void delete(theme untheme)
        {
            string ThemeDelete;

            ThemeDelete = ("theme where id ='" + untheme.IdTheme + "'");
            _dbal.Delete(ThemeDelete);
        }

        public void update(theme untheme)
        {
            string ThemeUpdate;

            ThemeUpdate = ("pays set id ='" + untheme.IdTheme + "' , nom = '" + untheme.Theme.Replace("'", "''") + "'");
            _dbal.Update(ThemeUpdate);
        }

        public List<theme> SelectAll()
        {
            List<theme> listFromage = new List<theme>();
            foreach (DataRow r in _dbal.SelectAll("theme").Rows)
            {
                listFromage.Add(new theme((int)r["idTheme"], (string)r["theme"]));
            }
            return listFromage;
        }

        public theme SelectByName(string theme)
        {
            DataRow r = _dbal.SelectByField("theme", "nom like '" + theme + "'").Rows[0];
            return new theme((int)r["idTheme"], (string)r["theme"]);
        }

        public theme SelectById(int idTheme)
        {
            DataRow r = _dbal.SelectById("theme", idTheme);
            return new theme((int)r["idTheme"], (string)r["theme"]);
        }
        #endregion
    }
}
