using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Business;
using Model.Data;

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour Transactions.xaml
    /// </summary>
    public partial class FenetreTransactions : Window
    {
        private DAOtransactions mytransaction;
        private DAOclients myclient;
        public FenetreTransactions(DAOclients mydaoClient, DAOtransactions mydaoTransaction)
        {
            mytransaction = mydaoTransaction;
            myclient = mydaoClient;
            //laTransaction = mytransaction;
            //lesClient = myclient;
            InitializeComponent();
            Transaction.DataContext = new viewModel.viewModeleClient(mydaoClient);
        }

        private void btn_GérerlesCrédits_Click(object sender, RoutedEventArgs e)
        {
            GérerCréditClient gererCreditClient = new GérerCréditClient(myclient,mytransaction);
            gererCreditClient.Show();
            this.Close();
        }

        private void btn_gérerClient_Click(object sender, RoutedEventArgs e)
        {
            GérerClients gererClient = new GérerClients(myclient,mytransaction);
            gererClient.Show();
            this.Close();
        }
    }
}
