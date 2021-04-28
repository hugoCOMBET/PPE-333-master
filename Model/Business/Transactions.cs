using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class Transactions
    {
        #region attribut privé
        private int _idTransaction;
        private Clients _idClient;
        private double _montantTransaction;
        #endregion

        #region constructeurs
        public Transactions(int UnIdTransaction, Clients UnClient, double UnMontantTransaction)
        {
            _idTransaction = UnIdTransaction;
            _idClient = UnClient;
            _montantTransaction = UnMontantTransaction;
            
        }
        public Transactions()
        {
            _idTransaction = 0;
            _idClient = new Clients();
            _montantTransaction = 0;
        }
        #endregion

        #region getteurs/setteurs
        public int getIdTransactions()
        {
            return _idTransaction;
        }
        public void setIdTransactions(int unIdTransaction)
        {
            _idTransaction = unIdTransaction;
        }
        public Clients getIdClient()
        {
            return _idClient;
        }
        public void setIdClient(Clients unIdClient)
        {
            _idClient = unIdClient;
        }
        public double getMontantTransaction()
        {
            return _montantTransaction;
        }
        public void setMontantTransaction(double unMontantTransaction)
        {
            _montantTransaction = unMontantTransaction;
        }
        #endregion
    }
}
