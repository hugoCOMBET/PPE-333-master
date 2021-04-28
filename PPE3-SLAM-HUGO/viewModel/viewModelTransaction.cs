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

        private Clients selectedClient = new Clients();
        private Transactions selectedTransaction = new Transactions();

        private ObservableCollection<Clients> listClient;
        private ObservableCollection<Transactions> listTransaction;

        public ObservableCollection<Clients> ListClient { get => listClient; set => listClient = value; }
        public ObservableCollection<Transactions> ListTransaction { get => listTransaction; set => listTransaction = value; }

        public viewModelTransaction(DAOclients thedaoClient)
        {
            vmDaoClients = thedaoClient;

            listClient = new ObservableCollection<Clients>(thedaoClient.SelectAll()); 
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
            get => selectedClient;
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
                }
            }
        }
        //public void LalistTransaction()
        //{
        //    ListTransaction = new ObservableCollection<Transactions>(vmDaoTransaction.SelectById(selectedClient.Id));
        //}
    }
}
