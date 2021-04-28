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
    public class DAOtransactions
    {
        private Dbal _dbal;

        private DAOclients TheDaoClient;

        public DAOtransactions(Dbal dbal,DAOclients unDaoClient)
        {
            _dbal = dbal;
            this.TheDaoClient = unDaoClient;
        }
        
        public List<Transactions> SelectAll()
        {
                List<Transactions> listTransaction = new List<Transactions>();
                DataTable myTable = this._dbal.SelectAll("Transactions");


                foreach (DataRow r in myTable.Rows)
                {
                Clients myClient = this.TheDaoClient.SelectById((int)r["idClient"]);
                listTransaction.Add(new Transactions((int)r["id"], myClient, (double)r["MontantTransaction"]));
                }
                return listTransaction;           
        }
        
        public Transactions SelectById(int id)
        {    
            DataRow r = this._dbal.SelectById("Transactions", id);
            Clients monClient = this.TheDaoClient.SelectById((int)r["id"]);
            return new Transactions
                ((int)r["id"],
                monClient,
                (double)r["MontantTransaction"]); 
        }
        //public List<Transactions> SelectByClient(int id)
        //{
        //    DataTable 
        //    return listTransactions
        //}
    }
}
