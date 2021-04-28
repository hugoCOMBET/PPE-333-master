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
    public class daoReservation
    {
        private Dbal _DBAL;

        public daoReservation(Dbal unDBAL)
        {
            _DBAL = unDBAL;
        }

        public void Insert(Reservations uneReservation)
        {
            _DBAL.Insert(" Reservation VALUES (" + uneReservation.IdReservation + "," + uneReservation.LeClient.getIdClient() + ","+uneReservation.LaSalle.IdSalle +","+uneReservation.LaTransaction.getIdTransactions()+",'"+uneReservation.DateReservation.ToString("yyyy-MM-dd") + "',"+uneReservation.NbJoueurs+","+uneReservation.NbObstacles+");");
        }

        public void Update(Reservations uneReservation)
        {
            _DBAL.Update(" Reservation SET idReservation = "+uneReservation.IdReservation+",idClient = "+uneReservation.LeClient.getIdClient() + ",idSalle = "+uneReservation.LaSalle.IdSalle + ",idTransaction = "+uneReservation.LaTransaction.getIdTransactions() + ",dateReservation = " + uneReservation.DateReservation.ToString("yyyy-MM-dd") + ", nbJoueurs = " + uneReservation.NbJoueurs + ", nbObstacles = " + uneReservation.NbObstacles + "WHERE idReservation = " + uneReservation.IdReservation + ";");
        }


        public void Delete(Reservations uneReservation)
        {
            _DBAL.Delete(" Reservation WHERE idReservation = "+uneReservation.IdReservation + ";");
        }

        public List<Reservations> SelectAll()
        {
            List<Reservations> uneListeReservation = new List<Reservations>();
            DataTable uneDataTable = _DBAL.SelectAll("Reservation");
            foreach(DataRow dtr in uneDataTable.Rows )
            {
                Reservations uneReservation = new Reservations
                    ((int)dtr["idReservation"], 
                    (Clients)dtr["idClient"], 
                    (salles)dtr["idSalle"], 
                    (Transactions)dtr["idTransaction"], 
                    (DateTime)dtr["dateReservation"], 
                    (int)dtr["nbJoueurs"], 
                    (int)dtr["nbObstacles"]);
                uneListeReservation.Add(uneReservation);
            }
            return uneListeReservation;
        }

        public Reservations SelectById(int idReservation)
        {
            DataRow UneDataRow = _DBAL.SelectById("Reservation", idReservation);
            Reservations uneReservation = new Reservations
                ((int)UneDataRow["idReservation"], 
                (Clients)UneDataRow["idClient"], 
                (salles)UneDataRow["idSalle"], 
                (Transactions)UneDataRow["idTransaction"], 
                (DateTime)UneDataRow["dateReservation"], 
                (int)UneDataRow["nbJoueurs"], 
                (int)UneDataRow["nbObstacles"]);
            return uneReservation;
        }
    }
}
