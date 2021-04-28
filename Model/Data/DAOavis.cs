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
        public class DAOavis
        {
            #region Attributs
            private Dbal _dbal;
            //private DAOclient _DAOclient;
            private DAOsalles _DAOsalles;
            #endregion

            #region Constructeur
            public void DAOAvis(Dbal dbal, DAOsalles DAOsalles)
            {
                _dbal = dbal;
                //_DAOclient = DAOclient;
                _DAOsalles = DAOsalles;
            }
            #endregion

            #region Autres méthodes
            public void insert(avis unavis,Clients unClient,salles uneSalle)
            {
                string AvisInsert;

                AvisInsert = ("avis (idAvis, idClient, idSalle, avis) values (" + unavis.IdAvis + "," + unClient.getIdClient() + "," + uneSalle.IdSalle + ",'" + unavis.Avis.Replace("'", "''") + "')");
                _dbal.Insert(AvisInsert);
            }

            public List<avis> SelectAll()
            {
                List<avis> listAvis = new List<avis>();
                foreach (DataRow r in _dbal.SelectAll("avis").Rows)
                {
                    listAvis.Add(new avis((int)r["idAvis"], (Clients)r["idClient"], (salles)r["idSalle"], (string)r["avis"]));
                }
                return listAvis;
            }

            public avis SelectById(int idAvis)
            {
                DataRow r = _dbal.SelectById("avis", idAvis);
                return new avis((int)r["idAvis"], (Clients)r["idClient"], (salles)r["idSalle"], (string)r["avis"]);
            }
            #endregion
        }
    }
