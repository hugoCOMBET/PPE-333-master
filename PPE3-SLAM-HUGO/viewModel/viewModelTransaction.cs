using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using Model.Business;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace PPE3_SLAM_HUGO.viewModel
{
    class viewModelTransaction : viewModelBase
    {
        private DAOclients vmDaoClients;
        private DAOtransactions vmDaoTransaction;

        private Transactions laTransaction = new Transactions();

        private Clients selectedClient = new Clients();
        private Transactions selectedTransaction = new Transactions();

        private ObservableCollection<Clients> listClient;
        private ObservableCollection<Transactions> listTransaction;

        public ObservableCollection<Clients> ListClient { get => listClient; set => listClient = value; }
        public ObservableCollection<Transactions> ListTransaction { get => listTransaction; set => listTransaction = value; }

        public viewModelTransaction(DAOclients thedaoClient,DAOtransactions thedaoTransaction)
        {
            vmDaoClients = thedaoClient;
            vmDaoTransaction = thedaoTransaction;

            listClient = new ObservableCollection<Clients>(thedaoClient.SelectAll()); 
            listTransaction = new ObservableCollection<Transactions>();
        }
        public string Nom
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.Nom;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (selectedClient.Nom != value)
                {
                    selectedClient.Nom = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }
        public Clients Selectedclient
        {
            get
            {
                this.UpdatelistTransaction();
                return selectedClient ;
            }
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;

                    OnPropertyChanged("Nom");
                    OnPropertyChanged("Prenom");
                    OnPropertyChanged("DateNaissance");
                    OnPropertyChanged("Email");
                    OnPropertyChanged("NumTel");
                    OnPropertyChanged("Adresse");
                    OnPropertyChanged("Adresse");
                    OnPropertyChanged("Credit");

                    //this.UpdatelistTransaction();
                }
            }
        }
        public void UpdatelistTransaction()
        {
            ListTransaction.Clear();
            List<Transactions>listTransactionClient = new List<Transactions>();
            listTransactionClient = vmDaoTransaction.SelectByClient(selectedClient);
            foreach (Transactions t in listTransactionClient)
            {
                listTransaction.Add(t);
            }
        }
        public Transactions Transaction
        {
            get => laTransaction;
            set
            {
                if (laTransaction != value)
                {
                    laTransaction = value;
                    OnPropertyChanged("idTransaction");
                    OnPropertyChanged("idlient");
                    OnPropertyChanged("MontantTransaction");
                }
            }
        }
    }
}
