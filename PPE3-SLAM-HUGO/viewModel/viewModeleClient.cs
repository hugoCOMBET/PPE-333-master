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
    class viewModeleClient : viewModelBase
    {
        private DAOclients vmDaoClients;
        
        private Clients selectedClient = new Clients();

        private ObservableCollection<Clients> listClient;

        public ObservableCollection<Clients> ListClient { get => listClient; set => listClient = value; }

        private ICommand updateCommand;
        private ICommand supprimerCommand;
        private ICommand ajouterCommand;

        public viewModeleClient(DAOclients thedaoClient)
        {
            vmDaoClients = thedaoClient;
            
            listClient = new ObservableCollection<Clients>(thedaoClient.SelectAll());
        }

        public string Prenom
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getPrenomClient();
                }
                else
                {
                    return null;
                }

            }
            set
            {
                if (selectedClient.getPrenomClient() != value)
                {
                    selectedClient.setPrenomClient(value);
                    OnPropertyChanged("Prenom");
                }
            }
        }
    
        public DateTime DateNaissance
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getDateNaissanceClient();
                }
                else
                {
                    return new DateTime();
                }
            }
            set
            {
                if (selectedClient.getDateNaissanceClient() != value)
                {
                    selectedClient.setDateNaissanceClient(value);
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("DateNaissance");
                }
            }
        }

        public string Email
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getEmailClient();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (selectedClient.getEmailClient() != value)
                {
                    selectedClient.setEmailClient(value);
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Email");
                }
            }
        }

        public string NumTel
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getTelPortableCLient();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (selectedClient.getTelPortableCLient() != value)
                {
                    selectedClient.setTelPortableCLient(value);
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("NumTel");
                }
            }
        }

        public string Adresse
        {
            get
            {
                if (selectedClient != null)
                {
                    return selectedClient.getAdresseClient();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (selectedClient.getAdresseClient() != value)
                {
                    selectedClient.setAdresseClient(value);
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Adresse");  
                }
            }
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

        private void SupprimerCommand()
        {
            this.vmDaoClients.Delete(this.selectedClient);
            int a = listClient.IndexOf(selectedClient);
            listClient.RemoveAt(a);
            MessageBox.Show("Client supprimé");
        }

        public ICommand SupprimerClient
        {
            get
            {
                if (this.supprimerCommand == null)
                {
                    this.supprimerCommand = new RelayCommand(() => SupprimerCommand(), () => true);
                }
                return this.supprimerCommand;
            }
        }

        private void UpdateCommand()
        {
            vmDaoClients.Update(selectedClient);
            RefreshListClient();
            //Clients backup = new Clients();
            //backup = selectedClient;
            //this.vmDaoClients.Update(this.selectedClient);
            //RefreshListClient();
            //int a = listClient.IndexOf(selectedClient);
            //listClient.Add(selectedClient);
            //listClient.RemoveAt(a + 1);
            //selectedClient = backup;
            MessageBox.Show("Mis à jour réussis");
        }

        public ICommand UpdateClient
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateCommand(), () => true);
                }
                return this.updateCommand;
            }
        }

        private void AjouterCommand()
        {
            foreach (Clients C in listClient)
            {
                int id = C.Id + 1;
                selectedClient.Id = id;
            }
            this.vmDaoClients.Insert(this.Selectedclient);
            RefreshListClient();
            listClient.Add(this.selectedClient);
            MessageBox.Show("ajout réussie");

            //Clients select = new Clients();
            //this.vmDaoClients.Insert(this.selectedClient);
            //listClient.Add(this.selectedClient);
            //select = this.selectedClient;
            //selectedClient = select;
            //MessageBox.Show("Joueur ajouté");
        }

        public ICommand AjouterClient
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

        public void RefreshListClient()
        {
            ObservableCollection<Clients> lalistClient = new ObservableCollection<Clients>(vmDaoClients.SelectAll());
            listClient.Clear();
            foreach (Clients c in lalistClient)
            {
                listClient.Add(c);
            }
        }
    }
}
