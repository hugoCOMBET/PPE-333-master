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
    class viewModelCredit : viewModelBase
    {
        private DAOclients vmDaoClients;

        private Clients selectedClient = new Clients();

        private ObservableCollection<Clients> listClient;
        private ObservableCollection<Transactions> listTransactions;

        private double creditautiliser;

        public ObservableCollection<Transactions> ListTransactions { get => listTransactions; set => listTransactions = value; }
        public ObservableCollection<Clients> ListClient { get => listClient; set => listClient = value; }

        private ICommand retirerCommand;
        private ICommand ajouterCommand;

        public viewModelCredit(DAOclients thedaoClient)
        {
            vmDaoClients = thedaoClient;

            listClient = new ObservableCollection<Clients>(thedaoClient.SelectAll());
        }


        public double Credit
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getCreditClient();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (selectedClient.getCreditClient() != value)
                {
                    selectedClient.setCreditClient(value);
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Credit");
                }
            }
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

        public double CreditaUtiliser
        {
            get
            {
                return creditautiliser;
            }
            set
            {
                creditautiliser = value; 
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

        private void AjouterCommand()
        {
            selectedClient.Credit = selectedClient.Credit + creditautiliser;
            vmDaoClients.Update(selectedClient);
            MessageBox.Show("Crédit ajoutés");
            new Transactions(1,selectedClient,creditautiliser);
        }
        public ICommand AjouterCredit
        {
            get
            {
                if (this.ajouterCommand == null)
                {
                    this.ajouterCommand = new RelayCommand(() => AjouterCommand(), () => true);
                }
                return this.ajouterCommand;
            }
        }
        private void RetirerCommand()
        {
            selectedClient.Credit = selectedClient.Credit - creditautiliser;
            vmDaoClients.Update(selectedClient);
            MessageBox.Show("Crédit retirés");
            //Transactions hugo = new Transactions(selectedClient.Id, creditautiliser);
        }
        public ICommand RetirerCredit
        {
            get
            {
                if (this.retirerCommand == null)
                {
                    this.retirerCommand = new RelayCommand(() => RetirerCommand(), () => true);
                }
                return this.retirerCommand;
            }
        }
    }
}
