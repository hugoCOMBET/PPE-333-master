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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model.Data;
using Model.Business;

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Logique d'interaction pour GérerClients.xaml
    /// </summary>
    public partial class GérerClients : Window
    {
        private DAOtransactions mytransaction;
        private DAOclients myclient;
        public GérerClients(DAOclients mydaoClient, DAOtransactions mydaoTransaction)
        {
            //mydaoClient = myclient;
            //mydaoTransaction = mytransaction;
            mytransaction = mydaoTransaction;
            myclient = mydaoClient;
            InitializeComponent();
            GererClient.DataContext = new viewModel.viewModeleClient(mydaoClient);
        }

        private void btn_gérerClient_Click(object sender, RoutedEventArgs e)
        {
            GérerCréditClient gererCreditClient = new GérerCréditClient(myclient,mytransaction);
            gererCreditClient.Show();
            this.Close();
        }

        private void btn_afficherTrans_Click(object sender, RoutedEventArgs e)
        {
            FenetreTransactions Transaction = new FenetreTransactions(myclient, mytransaction);
            Transaction.Show();
            this.Close();
        }

       
    }
}
